using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Content.Controllers;
using Project.Models;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private static bool isLogin = false;
        IHome obj;

        public HomeController(IHome i)
        {
            obj = i;
        }

        //
        // GET: /Home/

        public ActionResult Index(String category)
        {
            return View(obj.getProducts(category));
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginCustomer()
        {
            if(Request["name"].Length>0 && Request["passwd"].Length>0)
            {
                if (obj.loginUser(Request["name"],Request["passwd"]))
                {
                    isLogin = true;
                    Session["login"] = Request["name"];
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUpCustomer(Customer customer)
        {
            if (Request["Name"].Length > 0 && Request["Email"].Length > 0 && Request["Password"].Length > 0 && Request["confirm_passwd"].Length > 0)
            {
                if (obj.signupUser(Request["Name"],customer))
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    return RedirectToAction("Signup");
                }
            }
            else
            {
                return RedirectToAction("Signup");
            }
        }
        public ActionResult Details()
        {
            ViewBag.i = isLogin;
            return View(obj.getProduct(Request["title"]));
        }
        
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult Pictures()
        {
            return View(obj.getProduct(Request["title"]));
        }
        public JsonResult CheckUser(String name)
        {
            if (name.Length > 0)
            {
                Customer user = obj.getCustomer(name);

                if (user != null)
                {
                    return this.Json(true, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return this.Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return this.Json(true, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Signout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index");
        }
    }
}
