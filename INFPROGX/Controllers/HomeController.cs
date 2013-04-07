﻿using System;
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

            var Linq = (from OrData in db.OrderData
                      join or in db.Order
                          on OrData.OrderId equals or.OrderId
                       where or.UserName == currentuser
                          join prod in db.Product on OrData.ProductId equals prod.ProductId
                            select new ViewModel { OrderData = OrData, Order = or, Product = prod});

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
