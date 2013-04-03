using INFPROGX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}