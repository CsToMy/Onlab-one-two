﻿using System;
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
            JObject rawData = ReadBigTestFile("C:\\Users\\Tomi\\Documents\\OpenAcademiTestDB\\mag_papers_166.txt");
            JObject jsonGraph = null;

            try
            {
                List<JToken> result = rawData["result"].ToList(); // ArgumentNullException if its not exists
                jsonGraph = new JObject();
                JObject node = null;
                JObject edge = null;
                //JObject jOptions = null;
                JArray jEdges = new JArray();
                JArray jNodes = new JArray();
                //node-ok és élek külön szálon

                foreach (JToken item in result)
                {
                    node = new JObject();
                    node.Add("id", item["@rid"]);
                    node.Add("label", item["title"]);
                    node.Add("url", item["url"]);
                    node.Add("shape", "box");
                    jNodes.Add(node);
                    //node.RemoveAll(); // ha referenciákat ad át, akkor eztönkre teszi az egészet
                }

                string f = "", t = "";
                for (int i = 0; i < result.Count; i++)
                {
                    f = ""; t = "";
                    if (((JObject)result[i]).Property("out_") != null)
                    {
                        f = result[i]["@rid"].ToString();
                        foreach (var item in result[i]["out_"].ToList())
                        {
                            t = item.ToString();
                            edge = new JObject();
                            edge.Add("from", f);
                            edge.Add("to", t);
                            jEdges.Add(edge);
                        }
                    }
                    else
                    {
                        t = result[i]["@rid"].ToString();
                        foreach (var item in result[i]["in_"].ToList())
                        {
                            f = item.ToString();
                            edge = new JObject();
                            edge.Add("from", f);
                            edge.Add("to", t);
                            jEdges.Add(edge);
                        }
                    }
                }

                jsonGraph.Add("nodes", jNodes);
                jsonGraph.Add("edges", jEdges);
                //jsonGraph.Add("options", jOptions);
                Console.WriteLine(jsonGraph);
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        private static JObject ReadBigTestFile(string filePath)
        {
            JObject data = new JObject(JObject.Parse("{result:{}}"));
            // read JSON directly from a file
            using (StreamReader file = File.OpenText(filePath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                data["result"] = (JObject)JToken.ReadFrom(reader);
            }
            return data;
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
