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
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    }


    public class OrderData
    {
        [Key]
        public int OrderDataId { get; set; }
        public int OrderId { get; set; }
        public string ProductId { get; set; }
        public float PrinceOnOrder { get; set; }
        public int Amount { get; set; }
    }

    public class Shipping
    {
        [Key]
        public int ShippingId { get; set; }
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public float Cost { get; set; }
        public string Type { get; set; }
    }

    public class AbstractProduct
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
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

    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext() : base("DefaultConnection") { }
    }

    public class OrderDbContext : DefaultDbContext
    {
        public DbSet<Order> Order { get; set; }
    }

    public class OrderDataDbContext : DefaultDbContext
    {
        public DbSet<OrderData> OrderData { get; set; }
    }

    public class ShippingDbContext : DefaultDbContext
    {
        public DbSet<Shipping> Shipping { get; set; }
    }

    public class PowerSupplyDBContext : DefaultDbContext
    {
        public DbSet<PowerSupply> PowerSupply { get; set; }
    }

    public class CaseDbContext : DefaultDbContext
    {
        public DbSet<Case> Case { get; set; }
    }

    public class MoboDbContext : DefaultDbContext
    {
        public DbSet<Mobo> Mobo { get; set; }
    }

    public class RamDbContext : DefaultDbContext
    {
        public DbSet<Ram> Ram { get; set; }
    }

    public class HarddiskDbContext : DefaultDbContext
    {
        public DbSet<Harddisk> Harddisk { get; set; }
    }

    public class CpuDbContext : DefaultDbContext
    {
        public DbSet<Cpu> Cpu { get; set; }
    }

}