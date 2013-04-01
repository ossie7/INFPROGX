using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INFPROGX.Models;

namespace INFPROGX.DataAccessObjects
{
    public class EFProductData : IProductData
    {
        private ShopDbContext db = new ShopDbContext();

        public float getPriceById(int productId)
        {
            return db.Product.Find(productId).Price;
        }

        public IEnumerable<AbstractProduct> getAllProducts<AbstractProduct>()
        {
            return db.Product.ToList().OfType<AbstractProduct>();
        }

        public AbstractProduct getProductById(int id)
        {
            return db.Product.Find(id);
        }
    }
}