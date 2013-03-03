using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace INFPROGX.Models
{
    public class Cpu : AbstractProduct
    {
        public float Clock { get; set; }
    }
}