using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace INFPROGX.Models
{
    public class Shipping
    {
        [Key]
        public int ShippingId { get; set; }
        public int OrderId { get; set; }
        public DateTime Date { get; set; }

        [Range(0, 1000000)]
        public float Cost { get; set; }
        public string Type { get; set; }
    }
}