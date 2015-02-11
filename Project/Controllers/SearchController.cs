using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Content.Controllers
{
    public class SearchController : Controller
    {
        ISearch obj;

        public SearchController(ISearch i)
        {
            obj = i;
        }

        //
        // GET: /Search/

        public ActionResult SearchResult()
        {
            return View();
        }

        public JsonResult getProductsByTitle(String title)
        {
            var data = obj.getProductsByTitle(title);
            return this.Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getProductsByRange(int start, int end)
        {
            var data = obj.getProductsByRange(start,end);
            return this.Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getProductsByCompany(String company)
        {
            var data = obj.getProductsByCompany(company);
            return this.Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
