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

        public ActionResult ShowOrders()
        {
            ViewBag.Message = "All Orders";
            om = new OrderManager();
            
            return View(om.findAllOrders<Order>());
        }

        public ActionResult ShowOrderProd()
        {
            string currentuser = User.Identity.Name;

            var pre = (from hw in db.Order
                       where hw.UserName == currentuser
                       select new { OrderId = hw.OrderId }).ToList();
            
            System.Diagnostics.Debug.WriteLine(currentuser);
           /* var hoi = from h in db.OrderData
                      join hw in db.Order
                          on h.OrderId equals hw.OrderId
                     // where hw.UserName == currentuser
                       select new OrderLine {OrderDataId = h.OrderDataId,
                                OrderId = h.OrderId,
                                ProductId = h.ProductId,
                                PriceOnOrder = h.PriceOnOrder,
                                    Amount = h.Amount}; */
            /*
             *             var hoi = from h in db.OrderData
                      join hw in db.Order
                          on h.OrderId equals hw.OrderId
                      select new OrderLine
                      {
                          OrderDataId = h.OrderDataId,
                          OrderId = h.OrderId,
                          ProductId = h.ProductId,
                          PriceOnOrder = h.PriceOnOrder,
                          Amount = h.Amount
                      };
             * */

            var hoi = (from h in db.OrderData
                      join hw in db.Order
                          on h.OrderId equals hw.OrderId
                          where hw.UserName == currentuser
                       select new ViewModel { OrderData = h, Order = hw });

          //  var b = db.Order.Include(e => e.OrderLines);
            return View(hoi);
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
