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
            JObject rawData = dbMan.Read("ip:port/api", "");
            try
            {
                props = rawData.Properties().ToList<JProperty>();
            } catch (Exception e)
            {
                string x = e.Message;
            } finally
            {

            }
            data = rawData.ToString();
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