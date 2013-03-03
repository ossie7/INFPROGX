using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace INFPROGX.Models
{
    public class PowerSupply : AbstractProduct
    {
        public int Power { get; set; }
    }
}