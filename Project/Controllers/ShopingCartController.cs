using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Content.Controllers
{
    public class ShopingCartController : Controller
    {
        IShopingCart obj;

        public ShopingCartController(IShopingCart i)
        {
            obj = i;
        }

        //
        // GET: /ShopingCart/

        public ActionResult AddCart()
        {
            return View(obj.AddToCart(Request["title"],Request["quantity"],Request["price"]));
        }
        public ActionResult ShopingDetail()
        {
            return View(obj.getShopingDetail());
        }
        public ActionResult CheckOut()
        {
            obj.performCheckOut();
            return View();
        }
    }
}
