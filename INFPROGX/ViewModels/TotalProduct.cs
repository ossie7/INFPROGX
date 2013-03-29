using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INFPROGX.Models;

namespace INFPROGX.ViewModels
{
    public class TotalProduct
    {
        public Case        Case        { get; set; }
        public Cpu         Cpu         { get; set; }
        public Harddisk    Harddisk    { get; set; }
        public Mobo        Mobo        { get; set; }
        public PowerSupply PowerSupply { get; set; }
        public Ram         Ram         { get; set; }
        public float       TotalPrice  { get; set; }

        public List<AbstractProduct> Products()
        {
            AbstractProduct[] allProducts = new AbstractProduct[6]{Case, Cpu, Harddisk, Mobo, PowerSupply, Ram};
            List<AbstractProduct> products = new List<AbstractProduct>();
            foreach(AbstractProduct product in allProducts)
            {
                if (product != null) products.Add(product);
            }
            return products;
        }
    }
}