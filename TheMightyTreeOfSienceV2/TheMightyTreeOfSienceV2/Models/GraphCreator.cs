using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TheMightyTreeOfSienceV2.Models
{

    public class GraphCreator
    {
        private IList<JProperty> props = null;
        private DBManagger dbMan = null;        // handles database connections, read db's

        public GraphCreator()
        {
            dbMan = DBManagger.DBManaggerInstance;
            props = new List<JProperty>();
        }

        public bool GetGraph(ref string data)
        {
            if (data == null)
                return false;

            // Format: "{\"nodes\":[], \"edges\":[], \"options:{} }"
            // TODO: Read data with db managger and handle everything! (exceptions, couldn't read data, etc)
            // TODO: return false, if it's not possible
            // TODO: design an alg. which can form the data
            // TODO: fill the ref parameter with node and edge data
            // TODO: Exception handling
            // TODO: Measure performance
            JObject rawData = null;
            JObject jsonGraph = new JObject();

            try
            {
                //rawData = dbMan.Read("ip:port/api", "");
                rawData = dbMan.Read("próba", "teszt");

                List<JToken> result = rawData["result"].ToList(); // ArgumentNullException if its not exists
                JObject node = null;
                JArray jNodes = new JArray();

                foreach (JToken item in result)
                {
                    node = new JObject();
                    node.Add("id", item["@rid"]);
                    node.Add("label", item["title"]);
                    node.Add("shape", "ellipse");
                    jNodes.Add(node);
                }

                JArray jEdges = new JArray();
                JObject jOptions = new JObject();

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
                    }
                }

                jsonGraph.Add("nodes", jNodes);
                jsonGraph.Add("edges", jEdges);
            }
            catch (Exception e)
            {
                string x = e.Message;
            } finally
            {
                //data = rawData.ToString();
                data = jsonGraph.ToString();
            }

            return true;
        }

        public bool Search(string serchObject, ref string pos)
        {
            // TODO: search alg. in the list
            // TODO: buffer data
            // TODO: send REST request
            // TODO: Exception handling
            try
            {
                RestSharp.IRestRequest request = new RestSharp.RestRequest(RestSharp.Method.GET);
                RestSharp.IRestClient client = new RestSharp.RestClient("url");
            } catch (Exception e)
            {
                string x = e.Message;
            } finally
            {

            }
            return false;
        }
    }   
}