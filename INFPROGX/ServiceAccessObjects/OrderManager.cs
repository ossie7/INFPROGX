using INFPROGX.DataAccessObjects;
using INFPROGX.Models;
using INFPROGX.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INFPROGX.ServiceAccessObjects
{
    public class OrderManager
    {
        static OrderData od;

        public OrderManager()
        {
            od = new OrderData();
        }

        public static Double GetTotalPrice()
        {
            throw new NotSupportedException();
        }

        public void SaveOrder(Order order)
        {
            od.CreateOrder(order);
        }

        public IEnumerable<Order> findAllOrders<Order>()
        {
            return od.getAllOrders<Order>();
        }

        public IQueryable<ProductCount> ShowOrderProd(string name)
        {
            return od.ShowOrderProd(name);
        }

    }
}