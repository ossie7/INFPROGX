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
    }


    public class OrderData
    {
        [Key]
        public int OrderDataId { get; set; }
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public string ProductId { get; set; }
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

    public class CPU : AbstractProduct
    {
        public float Clock { get; set; }
    }

    public class BankAccount
    {
        [Key]
        public int BankAccountId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public float Balance { get; set; }
        public int AccessCode { get; set; }
    }

    public class OrderDBContext : DbContext
    {
        public DbSet<Order> Order { get; set; }
    }

    public class OrderDataDBContext : DbContext
    {
        public DbSet<OrderData> OrderData { get; set; }
    }

    public class PowerSupplyDBContext : DbContext
    {
        public DbSet<PowerSupply> PowerSupply { get; set; }
    }

    public class CaseDBContext : DbContext
    {
        public DbSet<Case> Case { get; set; }
    }

    public class MoboDBContext : DbContext
    {
        public DbSet<Mobo> Mobo { get; set; }
    }

    public class RAMDBContext : DbContext
    {
        public DbSet<Ram> Ram { get; set; }
    }

    public class HarddiskDBContext : DbContext
    {
        public DbSet<Harddisk> Harddisk { get; set; }
    }

    public class CPUDBContext : DbContext
    {
        public DbSet<CPU> CPU { get; set; }
    }

    public class BankAccountDBContext : DbContext
    {
        public DbSet<BankAccount> BankAccount { get; set; }
    }




}