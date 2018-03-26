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
            JObject x = ReadTestFile("C:\\Users\\Tomi\\Documents\\Visual Studio 2015\\Projects\\Onlab-one-two\\TheMightyTreeOfSienceV2\\TheMightyTreeOfSienceV2\\TestJsons\\testData3.json");

            List<JToken> result = x["result"].ToList(); // ArgumentNullException if its not exists
            JObject node = null;
            JObject jsonGraph = new JObject();
            JArray jNodes = new JArray();

            foreach (JToken item in result)
            {
                node = new JObject();
                node.Add("id", item["@rid"]);
                node.Add("label", item["title"]);
                node.Add("shape", "ellipse");
                node.Add("color", "red");
                jNodes.Add(node);
            }
            
            JArray jEdges = new JArray();
            JObject jOptions = new JObject();
            //out_  _in
            for (int i = 0; i < result.Count; i++)
            {
                JObject temp = (JObject)result[i];
                JObject edge = new JObject();
                string f, t;
                if (temp.Property("out_") != null)
                {
                    f = temp["@rid"].ToString();
                    foreach (var item in temp["out_"].ToList())
                    {
                        t = item.ToString();
                        edge = new JObject();
                        edge.Add("from", f);
                        edge.Add("to", t);
                        jEdges.Add(edge);
                    }
                    //Console.WriteLine("{1} Bemenő él. Értéke in_: {0}", temp["in_"].ToString(), i);
                }
                else
                {
                    t = temp["@rid"].ToString();
                    foreach (var item in temp["in_"].ToList())
                    {
                        edge = new JObject();
                        f = item.ToString();
                        edge.Add("from", f);
                        edge.Add("to", t);
                        jEdges.Add(edge);
                    }
                    //Console.WriteLine("{1} Kimenő él. Értéke out_: {0}", temp["out_"].ToString(), i);
                }
            }

            jsonGraph.Add("nodes", jNodes);
            jsonGraph.Add("edges", jEdges);
            //jsonGraph.Add("options", jOptions);
            Console.WriteLine(jsonGraph);
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
