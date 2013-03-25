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
    }
}