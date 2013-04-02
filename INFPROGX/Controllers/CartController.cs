using INFPROGX.Models;
using INFPROGX.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INFPROGX.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        //
        // GET: /Cart/

        public ActionResult Index()
        {
            TotalProduct model = (TotalProduct)Session["total"];
            
            ViewBag.Message = "De Winkelwagen";
            return View(model);
        }

        public ActionResult Checkout()
        {
            TotalProduct model = (TotalProduct)Session["total"];
            Debug.WriteLine(model.Products());
            List<AbstractProduct> products = model.Products();
            Order order = new Order();
            order.OrderLines = new List<OrderLine>();
            foreach(AbstractProduct product in products)
            {
                Debug.WriteLine(product.Name);
                OrderLine ol = new OrderLine();
                ol.Product = product;
               
                order.OrderLines.Add(ol);
            }
            
            return View(order);
        }
    }
}
