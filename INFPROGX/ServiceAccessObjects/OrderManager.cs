using INFPROGX.DataAccessObjects;
using INFPROGX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

    }
}