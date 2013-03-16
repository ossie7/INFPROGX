using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace INFPROGX.Models
{
    public class ShopDbContext : DbContext
    {
        //All DbContext classes had to be combined into one. Who knew?
        public ShopDbContext() : base("DefaultConnection") { }
        public DbSet<AbstractProduct> Product   { get; set; }
        public DbSet<Order>           Order     { get; set; }
        public DbSet<OrderData>       OrderData { get; set; }
        public DbSet<Shipping>        Shipping  { get; set; }
    }
}