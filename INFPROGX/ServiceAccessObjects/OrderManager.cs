using INFPROGX.DataAccessObjects;
using INFPROGX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INFPROGX.ServiceAccessObjects
{
    public static class OrderManager
    {

        public static Double GetTotalPrice()
        {
            throw new NotSupportedException();
        }

        public static void SaveOrder(List<AbstractProduct> products)
        {
            OrderData.CreateOrder(products);
        }
    }
}