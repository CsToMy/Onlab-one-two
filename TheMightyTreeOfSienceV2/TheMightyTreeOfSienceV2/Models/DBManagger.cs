using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using RestSharp;

namespace TheMightyTreeOfSienceV2.Models
{
    public class DBManagger
    {
        private static DBManagger instance = null;

        public static DBManagger DBManaggerInstance
        {
            get
            {
                if (instance == null)
                    instance = new DBManagger();
                
                return instance;
            }
        }

        public JObject Read(string url, string resource)
        {
            JObject rawData = ReadJsonFile("C:\\Users\\Tomi\\Documents\\Visual Studio 2015\\Projects\\Onlab-one-two\\TheMightyTreeOfSienceV2\\TheMightyTreeOfSienceV2\\TestJsons\\testData3.json");
            
            // TODO: Read everything, pack it and return with it. Don't ask questions.
            // TODO: Exception handling, throwing
            /*IRestRequest request = new RestRequest(Method.GET);
            request.Resource = resource;
            IRestClient client = new RestClient(url);
            //TODO: set request's properties. Header, body, params, etc...
            IRestResponse response = null;
            try
            {
                response = client.Execute(request); 
            }
            catch (Exception e)
            {
                string x = "Exception: " + e.Message + ".  Response:" + response.ErrorMessage;
                throw;
            }*/

            return rawData;
        }

        public string ReadVoice()
        {
            // TODO: Create db for this side project
            // TODO: 
            return null;
        }

        public JObject ReadGraphOptions()
        {
            return ReadJsonFile("C:\\Users\\Tomi\\Documents\\Visual Studio 2015\\Projects\\Onlab-one-two\\TheMightyTreeOfSienceV2\\TheMightyTreeOfSienceV2\\TestJsons\\testOptions.json");
        }

        // Only for testing
        private JObject ReadJsonFile(string filePath)
        {
            JObject jsonFile = JObject.Parse(File.ReadAllText(filePath));
            JObject data = null;
            // read JSON directly from a file
            using (StreamReader file = File.OpenText(filePath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject jsonData = (JObject)JToken.ReadFrom(reader);
                data = jsonData;
            }
            return data;
        }

        private DBManagger()
        {
            //...
        }
    }
}