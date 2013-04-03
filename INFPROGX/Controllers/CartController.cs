using INFPROGX.Filters;
using INFPROGX.Models;
using INFPROGX.ServiceAccessObjects;
using INFPROGX.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;


namespace INFPROGX.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        //
        // GET: /Cart/
        OrderManager om;

        private ShopDbContext db = new ShopDbContext();

        public ActionResult Index()
        {
            TotalProduct model = (TotalProduct)Session["total"];
            
            ViewBag.Message = "De Winkelwagen";
            return View(model);
        }

        [InitializeSimpleMembership]
        public ActionResult Checkout()
        {
            TotalProduct model = (TotalProduct)Session["total"];
            List<AbstractProduct> products = model.Products();
            Order order = new Order();
            order.OrderLines = new List<OrderLine>();
            foreach(AbstractProduct product in products)
            {
                Debug.WriteLine(product.Name);
                om = new OrderManager();
                OrderLine ol = new OrderLine();
                ol.ProductId = product.ProductId;
               
                order.OrderLines.Add(ol);
            }
            order.Date = DateTime.Now;
            string name = (string)User.Identity.Name;
            order.UserName = name;
            if (ModelState.IsValid)
            {
                om.SaveOrder(order);
            }
            return View(order);
        }
    }
}
