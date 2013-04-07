using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INFPROGX.ViewModels;
using INFPROGX.Models;
using INFPROGX.DataAccessObjects;
using INFPROGX.ServiceAccessObjects;
using System.Diagnostics;
using WebMatrix.WebData;


namespace INFPROGX.Controllers
{
    public class HomeController : Controller
    {
        private ShopDbContext db = new ShopDbContext();
        private IProductData productDao = new EFProductData();
        OrderManager om;

        public ActionResult Index()
        {
            TotalProduct model = new TotalProduct();
            if (Session["total"] != null)
            {
                model = (TotalProduct)Session["total"];
            }
            ViewBag.Message = "Welcome to the INPFROGX PCBUILDER!";

            ProductManager pm = new ProductManager(productDao);
            model.TotalPrice = pm.getTotalPrice(model.Products());
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

        public ActionResult ShowOrders()
        {
            ViewBag.Message = "All Orders";
            om = new OrderManager();
            
            return View(om.findAllOrders<Order>());
        }

        public ActionResult ShowOrderProd()
        {
            string currentuser = User.Identity.Name;

            var Linq = (from od in db.OrderData
                        group od by od.ProductId into op
                        join o in db.Order on op.FirstOrDefault().OrderId equals o.OrderId
                        where o.UserName == currentuser
                        join p in db.Product on op.FirstOrDefault().ProductId equals p.ProductId
                        select new ProductCount { Product = p, Count = op.Count() });

            return View(Linq);
        }

        public ActionResult Detail(int id)
        {

            Order order = (Order)db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }
    }
}
