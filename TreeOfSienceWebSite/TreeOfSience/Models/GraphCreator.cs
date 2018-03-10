using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreeOfSience.Models
{
    public class GraphCreator
    {
        private DBManagger dbMan = null;        // handles database connections, read db's
        private IList<string> graphData = null; // contains graph data for searching

        public GraphCreator()
        {
            dbMan = DBManagger.DBManaggerInstance;
            graphData = new List<string>();
        }

        public bool GetGraph(ref IList<string> data)
        {
            if (data == null)
                return false;

            List<string> processedData = new List<string>();
            string preProcessedData = dbMan.Read();
            processedData.Add(preProcessedData); // for testing
            data = processedData;
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