using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INFPROGX.Models;
using INFPROGX.DataAccessObjects;

namespace INFPROGX.ServiceAccessObjects
{
    public class ProductManager
    {
        EFProductData pd;

        public ProductManager()
        {
            pd = new EFProductData();
        }

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

        public IEnumerable<AbstractProduct> findAllProducts<AbstractProduct>()
        {
            return pd.getAllProducts<AbstractProduct>();
        }

        public AbstractProduct findProductById(int id)
        {
            return pd.getProductById(id);
        } 
    }
}