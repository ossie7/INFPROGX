using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INFPROGX.ViewModels;
using INFPROGX.Models;
using INFPROGX.DataAccessObjects;
using INFPROGX.ServiceAccessObjects;

namespace INFPROGX.Controllers
{
    public class HomeController : Controller
    {
        private ShopDbContext db = new ShopDbContext();
        private IProductData productDao = new EFProductData();

        public ActionResult Index()
        {
            TotalProduct model = new TotalProduct();
            if (Session["total"] != null)
            {
                model = (TotalProduct)Session["total"];
            }
            ViewBag.Message = "Welkom!";
            
            //TODO: bereken totalprice
            model.TotalPrice = ProductManager.getTotalPrice(model.Products(), productDao);
            return View(model);
        }

        public ActionResult Add(int id, string type)
        {
            TotalProduct model = new TotalProduct();
            if (Session["total"] != null)
            {
                model = (TotalProduct)Session["total"];
            }
            switch (type)
            {
                case("case"):
                    model.Case = (Case)db.Product.Find(id); break;
                case ("cpu"):
                    model.Cpu = (Cpu)db.Product.Find(id); break;
                case ("harddisk"):
                    model.Harddisk = (Harddisk)db.Product.Find(id); break;
                case ("mobo"):
                    model.Mobo = (Mobo)db.Product.Find(id); break;
                case ("powersupply"):
                    model.PowerSupply = (PowerSupply)db.Product.Find(id); break;
                case ("ram"):
                    model.Ram = (Ram)db.Product.Find(id); break;
            }
            Session["total"] = model;
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
