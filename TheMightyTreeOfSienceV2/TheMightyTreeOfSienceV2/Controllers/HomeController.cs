using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using TheMightyTreeOfSienceV2.Models;

namespace TheMightyTreeOfSienceV2.Controllers
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
            string x = searchText; //for debug
            if (searchText != null)
            {
                //TODO: buffer data
                //TODO: send REST request
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
                string x = "";
                if (networker.GetGraph(ref x))
                    data.Data = x; // TODO: create function which fill this list
                else // For testing.
                    ;
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
