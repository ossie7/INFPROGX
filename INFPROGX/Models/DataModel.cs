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


    public class OrderData
    {
        public int OrderDataId { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public string ProductId { get; set; }
        
    }

    public class AbstractProduct
    {
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public float Price { get; set; }
    }

    /*
         public class 
    {
        public int  { get; set; }
        public string  { get; set; }
        [ForeignKey("")]
        public string  { get; set; }

    }
     
     
     */


     public class Power
    {
        public int Power { get; set; }
        public string Description { get; set; }
      //  [ForeignKey("")]
   }

         public class Case
    {
        public float Height { get; set; }
        public string Description { get; set; }

    }
         public class Mobo
         {
             public string Format { get; set; }
             public string Description { get; set; }
         }

             public class ram
    {
        public int Size { get; set; }
        public string Description { get; set; }
    }
         public class Harddisk
    {
        public int size { get; set; }
        public string Description { get; set; }
    }
         public class CPU
    {
        public float Clock  { get; set; }
        public string Description { get; set; }
    }

         public class BankAccount
         {
             public int BankAccountId { get; set; }
             public int UserId { get; set; }
              [ForeignKey("UserId")]
             public float Balance { get; set; }
             public int AccessCode { get; set; }
         }

         public class Bank
         {
             public int BankAccountId { get; set; }
             public int UserId { get; set; }
             [ForeignKey("UserId")]
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

        public class AbstractProductDBContext : DbContext
    {
        public DbSet<AbstractProduct> AbstractProduct { get; set; }
    }

    public class PowerDBContext : DbContext
    {
        public DbSet<Power> Power { get; set; }
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
        public DbSet<ram> ram { get; set; }
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
    public class BankAccountDBContext : DbContext
    {
        public DbSet<Bank> Bank { get; set; }
    }




}