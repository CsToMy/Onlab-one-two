using System;
using System.Collections.Generic;
using System.Linq;
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

        public EmptyResult Search(string searchText)
        {
            //TODO: define return value
            string x = searchText;
            if (searchText != null)
            {
                string pos = null;
                if (!networker.Search(searchText, ref pos))
                    return new EmptyResult();
            }
            return new EmptyResult();
        }

        public JsonResult GetNetworkData()
        {
            JsonResult data = null;

            try
            {
                data = new JsonResult();
                data.ContentEncoding = Encoding.UTF8;
                data.ContentType = "application/json; charset=utf-8";
                data.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                
                IList<string> dataList = null;
                if (networker.GetGraph(ref dataList))
                    data.Data = "";
                else // For testing.
                    data.Data = "{\"nodes\":[{\"id\": \"1\", \"label\":\"html color\", \"color\": \"lime\"}, {\"id\": \"2\", \"label\":\"Node A\"}], \"edges\":[{\"from\": \"1\", \"to\": \"2\"}]}";//dummy example
            }
            catch (Exception e)
            {
                data = null;
            }
            return data;
        }
    }
}
