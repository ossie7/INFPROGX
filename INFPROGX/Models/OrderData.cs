using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace INFPROGX.Models
{
    public class OrderData
    {
        [Key]
        public int OrderDataId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        [Range(0, 1000000)]
        public float PriceOnOrder { get; set; }
        public int Amount { get; set; }
    }
}
