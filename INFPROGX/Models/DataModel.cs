using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace INFPROGX.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    }


    public class OrderData
    {
        [Key]
        public int OrderDataId { get; set; }
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public string ProductId { get; set; }
        public float PrinceOnOrder { get; set; }
        public int Amount { get; set; }
    }

    public class Shipping
    {
        [Key]
        public int ShippingId { get; set; }
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public float Cost { get; set; }
        public string Type { get; set; }
    }

    public class AbstractProduct
    {
        [Key]
        public int ProductId { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
    }

    public class PowerSupply : AbstractProduct
    {
        public int Power { get; set; }
    }

    public class Case : AbstractProduct
    {
        public float Height { get; set; }
    }

    public class Mobo : AbstractProduct
    {
        public string Format { get; set; }
    }

    public class Ram : AbstractProduct
    {
        public int Size { get; set; }
    }

    public class Harddisk : AbstractProduct
    {
        public int Size { get; set; }
    }

    public class Cpu : AbstractProduct
    {
        public float Clock { get; set; }
    }

    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Order { get; set; }
    }

    public class OrderDataDbContext : DbContext
    {
        public DbSet<OrderData> OrderData { get; set; }
    }

    public class ShippingDbContext : DbContext
    {
        public DbSet<Shipping> Shipping { get; set; }
    }

    public class PowerSupplyDBContext : DbContext
    {
        public DbSet<PowerSupply> PowerSupply { get; set; }
    }

    public class CaseDbContext : DbContext
    {
        public DbSet<Case> Case { get; set; }
    }

    public class MoboDbContext : DbContext
    {
        public DbSet<Mobo> Mobo { get; set; }
    }

    public class RamDbContext : DbContext
    {
        public DbSet<Ram> Ram { get; set; }
    }

    public class HarddiskDbContext : DbContext
    {
        public DbSet<Harddisk> Harddisk { get; set; }
    }

    public class CpuDbContext : DbContext
    {
        public DbSet<Cpu> Cpu { get; set; }
    }

}