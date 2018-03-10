using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;

namespace TreeOfSience.Models
{
    public class DBManagger
    {
        //TODO: DB context property.
        private DbContext cntx = null;
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

        public string Read()
        {
            if (!Connect())
            {
                //throw new Exception("Could not connect to the database!");
            }

            string rawData = ReadTestFile("C:\\Users\\Tomi\\Documents\\MEGA\\Repos\\Onlab-one-two\\TreeOfSienceWebSite\\TreeOfSience\\testData.json");
            
            string preProcessedData = rawData;

            //TODO: Read everything, pack it and return with it. Don't ask questions.

            //TODO: After that, close everything!

            Disconnect();
            
            return preProcessedData;
        }

        // Only for testing
        private string ReadTestFile(string filePath)
        {
            JObject jsonFile = JObject.Parse(File.ReadAllText(filePath));
            string data = "";
            // read JSON directly from a file
            using (StreamReader file = File.OpenText(filePath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject jsonData = (JObject)JToken.ReadFrom(reader);
                data = jsonData.ToString();
            }
            return data;
        }

        private DBManagger()
        {
            //...
        }

        private bool Connect()
        {
            //TODO: Connect to the database and create context. Return false, if it couldn't connect and destroy DB context property
            return false;
        }


        private void Disconnect()
        {
            //TODO: Disconnect from the database and destroy DB context at all cost!
        }
    }
}