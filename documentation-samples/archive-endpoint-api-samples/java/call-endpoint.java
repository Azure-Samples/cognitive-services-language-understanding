// This sample uses the Apache HTTP client from HTTP Components (http://hc.apache.org/httpcomponents-client-ga/)

// You need to add the following Apache HTTP client libraries to your project:
// httpclient-4.5.3.jar
// httpcore-4.4.6.jar
// commons-logging-1.2.jar

import java.net.URI;
import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.utils.URIBuilder;
import org.apache.http.impl.client.HttpClients;
import org.apache.http.util.EntityUtils;

public class LuisGetRequest {

    public static void main(String[] args) 
    {
        HttpClient httpclient = HttpClients.createDefault();

        try
        {

            // The ID of a public sample LUIS app that recognizes intents for turning on and off lights
            String AppId = "df67dcdb-c37d-46af-88e1-8b97951ca1c2";
            
            // Add your subscription key 
            String SubscriptionKey = "YOUR-SUBSCRIPTION-KEY";

        URIBuilder builder = 
            new URIBuilder("https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/" + AppId + "?");

            builder.setParameter("q", "turn on the left light");
            builder.setParameter("timezoneOffset", "0");
            builder.setParameter("verbose", "false");
            builder.setParameter("spellCheck", "false");
            builder.setParameter("staging", "false");

            URI uri = builder.build();
            HttpGet request = new HttpGet(uri);
            request.setHeader("Ocp-Apim-Subscription-Key", SubscriptionKey);

            HttpResponse response = httpclient.execute(request);
            HttpEntity entity = response.getEntity();


            if (entity != null) 
            {
                System.out.println(EntityUtils.toString(entity));
            }
        }

        catch (Exception e)
        {
            System.out.println(e.getMessage());
        }
    }
}
