using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INFPROGX.Models;
using INFPROGX.DataAccessObjects;

namespace INFPROGX.ServiceAccessObjects
{
    public static class ProductManager
    {
        public static float getTotalPrice(ICollection<AbstractProduct> products, IProductData DAO)
        {
            float total = 0.0f;
            if (products.Count < 1) return total;
            foreach(AbstractProduct product in products)
            {
                total += DAO.getPriceById(product.ProductId);
            }
            return total;
        }
    }
}