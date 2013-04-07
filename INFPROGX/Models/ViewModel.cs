using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INFPROGX.Models
{
    public class ViewModel
    {
        public Order Order { get; set; }
        public OrderLine OrderData { get; set; }
        public AbstractProduct Product { get; set; }
    }
}