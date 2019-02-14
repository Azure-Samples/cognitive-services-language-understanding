using System;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;

namespace UsePredictionRuntime
{
    class Program
    {
        static void Main(string[] args)
        {

            var luisResult = GetPrediction().Result;

            // Display query
            Console.WriteLine("Query:'{0}'", luisResult.Query);

            // Display most common properties of query result
            Console.WriteLine("Top intent is '{0}' with score {1}", luisResult.TopScoringIntent.Intent,luisResult.TopScoringIntent.Score);

            // Display all entities detected in query utterance
            foreach (var entity in luisResult.Entities)
            {
                Console.WriteLine("{0}:'{1}' begins at position {2} and ends at position {3}", entity.Type, entity.Entity, entity.StartIndex, entity.EndIndex);
            }

            Console.Write("done");

        }
        static async System.Threading.Tasks.Task<Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models.LuisResult> GetPrediction() {

            // Use Language Understanding or Cognitive Services key
            // to create authentication credentials
            var endpointPredictionkey = "<REPLACE-WITH-YOUR-KEY>";
            var credentials = new ApiKeyServiceClientCredentials(endpointPredictionkey);

            // Create Luis client and set endpoint
            // region of endpoint must match key's region
            var luisClient = new LUISRuntimeClient(credentials, new System.Net.Http.DelegatingHandler[] { });
            luisClient.Endpoint = "https://<REPLACE-WITH-YOUR-KEY-REGION>.api.cognitive.microsoft.com";

            // Create prediction client
            var prediction = new Prediction(luisClient);

            // Set query values

            // public Language Understanding Home Automation app
            var appId = "df67dcdb-c37d-46af-88e1-8b97951ca1c2";

            // query specific to home automation app
            var query = "turn on the bedroom light";

            // common settings for remaining parameters
            Double? timezoneOffset = null;
            var verbose = true;
            var staging = false;
            var spellCheck = false;
            String bingSpellCheckKey = null;
            var log = false;
            System.Threading.CancellationToken cancellationToken = new System.Threading.CancellationToken();

            // get prediction
            return await prediction.ResolveAsync(appId, query, timezoneOffset, verbose, staging, spellCheck, bingSpellCheckKey, log, cancellationToken);

        }
    }
}
