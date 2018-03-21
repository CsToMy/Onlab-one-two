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

            JObject rawData = dbMan.Read("ip:port/api", "");
            List<JProperty> properties = rawData.Properties().ToList<JProperty>();

            data = rawData.ToString();
            // kell: "{\"nodes\":[], \"edges\":[], \"options:{} }"
            string jsonText = "{";
            
            //data = jsonText;

            //TODO: Read data with db managger and handle everything! (exceptions, couldn't read data, etc)
            //TODO: return false, if it's not possible
            //TODO: design an alg. which can form the data
            //TODO: fill the ref parameter with node and edge data
            return true;
        }

        public bool Search(string serchObject, ref string pos)
        {
            // TODO: search alg. in the list
            return false;
        }

        private void CreateTreeGraph()
        {
            //TODO: after read all the data, create a tree graph
        }
    }   
}