using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace INFPROGX.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public string Password { get; set; }

    }

    public class OrderDBContext : DbContext
    {
        public DbSet<Order> Order { get; set; }
    }


}