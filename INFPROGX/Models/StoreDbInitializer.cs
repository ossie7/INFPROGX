using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace INFPROGX.Models
{
    //seed db
    public class StoreDbInitializer : DropCreateDatabaseAlways<ShopDbContext>
    {
        protected override void Seed(ShopDbContext context)
        {
       //     public DbSet<AbstractProduct> Product   { get; set; }
      //  public DbSet<Order>           Order     { get; set; }
      //  public DbSet<OrderLine>       OrderData { get; set; }
       // public DbSet<Shipping>        Shipping  { get; set; }
            

            //vb.
          //  context.Order.Add(new Order { OrderId = 1, UserId = 1 });
            //etc...
        }

    }
}