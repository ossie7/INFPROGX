using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
//dit hoort te werken maar er mag geen 2x zelfde shipping bestaan anders gaat eht neit builden
namespace INFPROGX.Models
{ /*
    public class Shipping
    {
        public int ShippingId { get; set; }
        public int OrderId { get; set; }

        public DateTime Date { get; set; }
        // kan beter met decimal worden gedaan aangezien het preciezer is
        //hieronder zorgt voor betere afbaking ook bij ui door middel van jquiry
        //euroteken/dollar etc.. erbij
        [Range(1, 1000000)]
        [DataType(DataType.Currency)]
        public float Cost { get; set; }
        public string Type { get; set; }
    }
 
    public class ShippingDbContext : DbContext
    {
        public DbSet<Shipping> Shipping { get; set; }
    }*/
}