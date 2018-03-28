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
        private DBManagger dbMan = null;        // handles database connections, read db's

        public GraphCreator()
        {
            dbMan = DBManagger.DBManaggerInstance;
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
            JObject jsonGraph = null;

            try
            {
                //rawData = dbMan.Read("ip:port/api", "");
                rawData = dbMan.Read("próba", "teszt");
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
                        
                        for (int j=0; j<result[i]["out_"].ToList().Count; ++j)
                        {
                            t = result[i]["out_"].ToList()[j].ToString(); // ugly...
                            edge = new JObject();
                            edge.Add("from", f);
                            edge.Add("to", t);
                            jEdges.Add(edge);
                        }
                    }
                    else
                    {
                    /*    t = result[i]["@rid"].ToString();
                        for (int j = 0; j< result[i]["in_"].ToList().Count; ++j)
                        {
                            f = result[i]["in_"].ToList()[j].ToString();
                            edge = new JObject();
                            edge.Add("from", f);
                            edge.Add("to", t);
                            jEdges.Add(edge);
                        }
                     */
                    }                    
                }

                jsonGraph.Add("nodes", jNodes);
                jsonGraph.Add("edges", jEdges);
                jsonGraph.Add("options", dbMan.ReadGraphOptions());
            }
            catch (Exception e)
            {
                JObject errorJson = new JObject();
                JObject info = new JObject();

                info.Add("systemMessage", e.Message);
                info.Add("usrInfo", e.Data.ToString());
                info.Add("innerException", e.InnerException.ToString());
                info.Add("source", e.Source);
                info.Add("from", "2"); // 1=DbMgm, 2=GraphCreator, 3=Controller

                errorJson.Add("error", info);
                throw new Exception(errorJson.ToString());
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