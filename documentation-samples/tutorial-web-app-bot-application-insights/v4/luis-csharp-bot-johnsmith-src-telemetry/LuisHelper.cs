// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.AI.Luis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.ApplicationInsights;
using System.Collections.Generic;

namespace Microsoft.BotBuilderSamples
{
    public static class LuisHelper
    {
        public static async Task<BookingDetails> ExecuteLuisQuery(IConfiguration configuration, ILogger logger, ITurnContext turnContext, CancellationToken cancellationToken)
        {
            var bookingDetails = new BookingDetails();

            try
            {
                // Create the LUIS settings from configuration.
                var luisApplication = new LuisApplication(
                    configuration["LuisAppId"],
                    configuration["LuisAPIKey"],
                    "https://" + configuration["LuisAPIHostName"]
                );

                var recognizer = new LuisRecognizer(luisApplication);

                // The actual call to LUIS
                var recognizerResult = await recognizer.RecognizeAsync(turnContext, cancellationToken);

                LuisHelper.LogToApplicationInsights(configuration, turnContext, recognizerResult);

                var (intent, score) = recognizerResult.GetTopScoringIntent();
                if (intent == "Book_flight")
                {
                    // We need to get the result from the LUIS JSON which at every level returns an array.
                    bookingDetails.Destination = recognizerResult.Entities["To"]?.FirstOrDefault()?["Airport"]?.FirstOrDefault()?.FirstOrDefault()?.ToString();
                    bookingDetails.Origin = recognizerResult.Entities["From"]?.FirstOrDefault()?["Airport"]?.FirstOrDefault()?.FirstOrDefault()?.ToString();

                    // This value will be a TIMEX. And we are only interested in a Date so grab the first result and drop the Time part.
                    // TIMEX is a format that represents DateTime expressions that include some ambiguity. e.g. missing a Year.
                    bookingDetails.TravelDate = recognizerResult.Entities["datetime"]?.FirstOrDefault()?["timex"]?.FirstOrDefault()?.ToString().Split('T')[0];
                }
            }
            catch (Exception e)
            {
                logger.LogWarning($"LUIS Exception: {e.Message} Check your LUIS configuration.");
            }

            return bookingDetails;
        }
        public static void LogToApplicationInsights(IConfiguration configuration, ITurnContext turnContext, RecognizerResult result)
        {
            // Create Application Insights object
            TelemetryClient telemetry = new TelemetryClient();

            // Set Application Insights Instrumentation Key from App Settings
            telemetry.InstrumentationKey = configuration["BotDevAppInsightsKey"];

            // Collect information to send to Application Insights
            Dictionary<string, string> logProperties = new Dictionary<string, string>();

            logProperties.Add("BotConversation", turnContext.Activity.Conversation.Name);
            logProperties.Add("Bot_userId", turnContext.Activity.Conversation.Id);

            logProperties.Add("LUIS_query", result.Text);
            logProperties.Add("LUIS_topScoringIntent_Name", result.GetTopScoringIntent().intent);
            logProperties.Add("LUIS_topScoringIntentScore", result.GetTopScoringIntent().score.ToString());


            // Add entities to collected information
            int i = 1;
            if (result.Entities.Count > 0)
            {
                foreach (var item in result.Entities)
                {
                    logProperties.Add("LUIS_entities_" + i++ + "_" + item.Key, item.Value.ToString());
                }
            }

            // Send to Application Insights
            telemetry.TrackTrace("LUIS", ApplicationInsights.DataContracts.SeverityLevel.Information, logProperties);

        }
    }
}
