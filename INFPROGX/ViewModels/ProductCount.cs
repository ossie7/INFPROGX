using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INFPROGX.Models;

namespace INFPROGX.ViewModels
{
    public class ProductCount
    {
        public AbstractProduct Product { get; set; }
        public int Count { get; set; }
    }
}