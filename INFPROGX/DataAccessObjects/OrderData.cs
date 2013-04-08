using INFPROGX.Models;
using INFPROGX.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace INFPROGX.DataAccessObjects
{
    public class OrderData
    {

        private ShopDbContext db = new ShopDbContext();

        public Double GetPriceById(int id)
        {
            throw new NotSupportedException();
        }

        public void CreateOrder(Order order)
        {
            db.Order.Add(order);
            db.SaveChanges(); 
        }

        public IEnumerable<Order> getAllOrders<Order>()
        {
            return db.Order.ToList().OfType<Order>();
        }

        public IQueryable<ProductCount> ShowOrderProd(string name)
        {
            

            var Linq = (from od in db.OrderData
                        group od by od.ProductId into op
                        join o in db.Order on op.FirstOrDefault().OrderId equals o.OrderId
                        where o.UserName == name
                        join p in db.Product on op.FirstOrDefault().ProductId equals p.ProductId
                        select new ProductCount { Product = p, Count = op.Count() });

            return Linq;

        }
    }
}