using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace JSONTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            //JObject x = new JObject("{\"name\":\"Bob\", \"age\":32}");
            JObject x = ReadTestFile("C:\\Users\\Tomi\\Documents\\Visual Studio 2015\\Projects\\TheMightyTreeOfSienceV2\\TheMightyTreeOfSienceV2\\TestJsons\\testData.json");
            List<JProperty> props = x.Properties().ToList<JProperty>();
            foreach (JProperty prop in props)
            {
                Console.Write("{0}, ",prop.Name);
            }
            Console.WriteLine();
            /*JArray nodeList = JArray.Parse(x[props[0].Name].ToString());
            Console.WriteLine(nodeList.Count);
            for (int i = 0; i < nodeList.Count; i++)
            {
                Console.Write(nodeList[i].ToString());
            }
            */
            /*x = ReadRDB("ip:port/api");
            Console.WriteLine(x.Count.ToString());*/
            Console.ReadKey();
        }

        private static JObject ReadRDB(string url)
        {
            JObject preciusData = null;
            RestClient preciousClient = new RestClient(url);
            preciousClient.FollowRedirects = true;
            RestRequest req = new RestRequest(Method.GET);
            req.Timeout = 500;

            return preciusData;
        }

        private static JObject ReadTestFile(string filePath)
        {
            JObject jsonFile = JObject.Parse(File.ReadAllText(filePath));
            JObject data = null;
            // read JSON directly from a file
            using (StreamReader file = File.OpenText(filePath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject jsonData = (JObject)JToken.ReadFrom(reader);
                string temp = jsonData.ToString().Replace("\n", "").Replace("\r", "").Replace("\t", "").Replace(" ", "");
                data = JObject.Parse(temp);
            }
            return data;
        }
    }
}
