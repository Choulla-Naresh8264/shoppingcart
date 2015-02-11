using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using System.IO;

namespace Project.Content.Controllers
{
    public class AdminController : Controller
    {
        IAdmin obj;

        public AdminController(IAdmin i)
        {
            obj = i;
        }

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAdmin()
        {
            if (obj.loginAdmin(Request["name"],Request["passwd"]))
            {
                return RedirectToAction("Menu");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Products(String category)
        {
            return View(obj.getProduct(category));
        }

        public ActionResult ProfitLoss()
        {
            return View();
        }

        public ActionResult Reports()
        {
            obj.reports();
            return View();
        }

        [HttpPost]
        public ActionResult Delete()
        {
            obj.delete(Request["title"]);
            return RedirectToAction("Menu");
        }

        [HttpPost]
        public ActionResult Edit()
        {
            return View(obj.edit(Request["title"]));
        }

        [HttpPost]
        public ActionResult Update(Product product)
        {
            product.Category = Request["categori"];
            product.Title = Request["tit"];
            product.Pictures = Request["picture"];

            obj.update(product);

            return RedirectToAction("Menu");
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddItem()
        {
            String fileNames = null;

            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i];
                file.SaveAs(Server.MapPath(@"~\Files\" + file.FileName));
                if (i == 0)
                {
                    fileNames = file.FileName;
                }
                else
                {
                    fileNames = fileNames + ";" + file.FileName;
                }
            }

            obj.addProduct(Request["title"],Request["price"],Request["purchase"],Request["company"],Request["catagory"],fileNames);

            return RedirectToAction("Menu");
        }
        public ActionResult Signout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index");
        }
    }
}
