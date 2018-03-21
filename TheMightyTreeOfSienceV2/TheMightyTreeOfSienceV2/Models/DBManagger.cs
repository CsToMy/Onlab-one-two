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
            //string rawData = ReadTestFile("C:\\Users\\Tomi\\Documents\\MEGA\\Repos\\Onlab-one-two\\TreeOfSienceWebSite\\TreeOfSience\\testData.json");
            JObject rawData = ReadTestFile("C:\\Users\\Tomi\\Documents\\Visual Studio 2015\\Projects\\TheMightyTreeOfSienceV2\\TheMightyTreeOfSienceV2\\TestJsons\\testData.json");
            
            //TODO: Read everything, pack it and return with it. Don't ask questions.
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
            return null;
        }

        // Only for testing
        private JObject ReadTestFile(string filePath)
        {
            JObject jsonFile = JObject.Parse(File.ReadAllText(filePath));
            JObject data = null;
            // read JSON directly from a file
            using (StreamReader file = File.OpenText(filePath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject jsonData = (JObject)JToken.ReadFrom(reader);
                data = jsonData;//.ToString();
            }
            return data;
        }

        private DBManagger()
        {
            //...
        }
    }
}