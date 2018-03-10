using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using TreeOfSience.Models;

namespace TreeOfSience.Controllers
{
    public class HomeController : Controller
    {
        private GraphCreator networker = null;

        public HomeController()
        {
            networker = new GraphCreator();
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Search(string searchText)
        {
            //TODO: define return value
            string x = searchText;
            if (searchText != null)
            {
                string pos = null; // contains the node id
                if (!networker.Search(searchText, ref pos))
                    return new JsonResult();
                else
                    ;//TODO: jump to the found node
            }
            return new JsonResult();
        }

        public JsonResult GetNetworkData()
        {
            JsonResult data = null;

            try
            {
                // init json response
                data = new JsonResult();
                data.ContentEncoding = Encoding.UTF8;
                data.ContentType = "application/json; charset=utf-8";
                data.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                
                // read json data
                IList<string> dataList = new List<string>();
                if (networker.GetGraph(ref dataList))
                    data.Data = dataList[0]; // TODO: create function which fill this list
                else // For testing.
                    data.Data = "{\"nodes\":[{\"id\": \"1\", \"label\":\"html color\", \"color\": \"lime\"}, {\"id\": \"2\", \"label\":\"Node A\"}], \"edges\":[{\"from\": \"1\", \"to\": \"2\"}]}";//dummy example
            }
            catch (Exception e)
            {
                var x = e.Message;
                data = null;
            }
            return data;
        }
    }
}
