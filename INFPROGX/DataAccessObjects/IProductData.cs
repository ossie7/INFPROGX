using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INFPROGX.Models;

namespace INFPROGX.DataAccessObjects
{
    public interface IProductData
    {
        float getPriceById(int productId);
        IEnumerable<AbstractProduct> getAllProducts<AbstractProduct>();
        AbstractProduct getProductById(int id);
    }
}