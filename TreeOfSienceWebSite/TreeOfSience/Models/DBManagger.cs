using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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

        public IList<string> Read()
        {
            if (!Connect())
            {
                throw new Exception("Could not connect to the database!");
            }

            //TODO: Read everything, pack it and return with it. Don't ask questions.
            
            //TODO: After that, close everything!
            Disconnect();
            
            return null;
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