using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace INFPROGX.Models
{
    public class OrderData
    {
        [Key]
        public int OrderDataId { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
                
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual AbstractProduct Product { get; set; }


        [Range(0, 1000000)]
        public float PriceOnOrder { get; set; }
        public int Amount { get; set; }
    }
}
