const appInsights = require('applicationinsights');
const _ = require("underscore");


// Log LUIS results to Application Insights
// must flatten as name/value pairs
var appInsightsLog = (botContext,luisResponse) => {
    
    appInsights.setup(process.env.MicrosoftApplicationInsightsInstrumentationKey).start();
    const appInsightsClient = appInsights.defaultClient;

    // put bot context and LUIS results into single object
    var data = Object.assign({}, {'botContext': botContext._activity}, {'luisResponse': luisResponse});

    // Flatten data into name/value pairs
    flatten = (x, result, prefix) => {
        if(_.isObject(x)) {
            _.each(x, (v, k) => {
                flatten(v, result, prefix ? prefix + '_' + k : k)
            })
        } else {
            result["LUIS_" + prefix] = x
        }
        return result;
    }

    // call fn to flatten data
    var flattenedData = flatten(data, {});

    // ApplicationInsights Trace 
    console.log(JSON.stringify(flattenedData));

    // send data to Application Insights
    appInsightsClient.trackTrace({message: "LUIS", severity: appInsights.Contracts.SeverityLevel.Information, properties: flattenedData});
}

module.exports.appInsightsLog = appInsightsLog;