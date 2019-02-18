using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;

namespace BuildModel
{
    class Program
    {
        static void Main(string[] args)
        {

            // authoring Key found in LUIS portal under user settings
            var cogServicesAllInOneKey = "<YOUR-AUTHORING-KEY>";
            var credentials = new ApiKeyServiceClientCredentials(cogServicesAllInOneKey);

            // set parameters for app
            var resourceRegion = "westus";
            var culture = "en-us";
            var appName = "myEnglishApp-02182019-1125am";
            var description = "app made with .Net SDK";
            var versionId = "0.1";

            // create client object
            var authoringClient = new LUISAuthoringClient(credentials, new System.Net.Http.DelegatingHandler[] { });
            authoringClient.Endpoint = "https://westus.api.cognitive.microsoft.com/";

            // create app
            var appId = CreateApp(authoringClient, resourceRegion, appName, versionId, culture, description);

            // create intent
            var intent = "FindForm";
            var intentID = CreateIntent(authoringClient, resourceRegion, appId, versionId, intent);

            // create entity `HRF-number regular express
            var entityRegEx = "hrf-[0-9]{6}";
            var entityName = "HRF-number";
            var regularExpressEntity = new RegexModelCreateObject(entityRegEx, entityName);
            var entityId = CreateRegularExpressionEntity(authoringClient, resourceRegion, appId, versionId, regularExpressEntity);

            // add example utterance with 1 entity to intent
            var entity = "HRF-number";
            var utterance = "When was hrf-123456 published?";
            var taggedEntity = new EntityLabelObject(entity, 9, 18);
            var exampleUtteranceId = AddExampleUtterance(authoringClient, appId, versionId, intent, utterance, taggedEntity);

        }
        static int AddExampleUtterance(LUISAuthoringClient client, Guid appId, string versionId, string intent, string utterance, EntityLabelObject taggedEntity)
        {
            try
            {
                // creating list and adding 1 item
                var taggedEntities = new List<EntityLabelObject>();
                taggedEntities.Add(taggedEntity);

                // create example object
                var exampleLabelObject = new ExampleLabelObject(utterance, taggedEntities, intent);

                // create example
                var response = client.Examples.AddAsync(appId, versionId, exampleLabelObject, CancellationToken.None).Result;

                if (response.ExampleId == null)
                    return default(int);
                else
                    return response.ExampleId.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw ex;
            }
        }
        static Guid CreateRegularExpressionEntity(LUISAuthoringClient client, string resourceRegion, Guid appId, string versionId, RegexModelCreateObject entity)
        {
            try
            {

                // create model for regular expression entity
                // custom headers is null
                var response = client.Model.CreateRegexEntityModelWithHttpMessagesAsync(appId, versionId, entity, null, CancellationToken.None).Result;

                // get entityId from `Location` header - trim away URL part
                var newEntityId = response.Response.Headers.Location.ToString();
                newEntityId = newEntityId.Replace(String.Format("https://{0}.api.cognitive.microsoft.com/luis/api/v2.0/apps/{1}/versions/{2}/regexentities/", resourceRegion, appId, versionId), "");

                return new Guid(newEntityId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw ex;
            }
        }
        static Guid CreateIntent(LUISAuthoringClient client, string resourceRegion, Guid appId, string versionId, string intent)
        {
            try
            {

                // create model for intent
                // custom headers is null
                var response = client.Model.AddIntentWithHttpMessagesAsync(appId, versionId, new ModelCreateObject(intent), null, CancellationToken.None).Result;

                // get intentId from `Location` header - trim away URL part 
                var newIntentId = response.Response.Headers.Location.ToString();
                newIntentId = newIntentId.Replace(String.Format("https://{0}.api.cognitive.microsoft.com/luis/api/v2.0/apps/{1}/versions/{2}/intents/", resourceRegion, appId, versionId), "");

                return new Guid(newIntentId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw ex;
            }
        }
        static Guid CreateApp(LUISAuthoringClient client, string resourceRegion, string appName, string versionId, string culture, string description)
        {
            try
            {
                // don't set because it isn't used by LUIS
                var domain = String.Empty;
                var usageScenario = String.Empty;

                // create app definition object 
                var app = new ApplicationCreateObject(culture, appName, domain, description, versionId, usageScenario);

                // create app
                var response = client.Apps.AddWithHttpMessagesAsync(app, null, CancellationToken.None).Result;

                // get appId from `Location` header - trim away URL part to get appId
                var newAppId = response.Response.Headers.Location.ToString().Replace(String.Format("https://{0}.api.cognitive.microsoft.com/luis/api/v2.0/apps/", resourceRegion), "");

                // convert string to guid and return it
                return new Guid(newAppId);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw ex;
            }
        }
    }
}

