using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace INFPROGX.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public string UserName { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; }
        public DateTime Date { get; set; }
    }
}
