using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrabAndGo
{
    public class BOPackage
    {
        public string AcceptTime { get; set; }
        public string CustomerId { get; set; }
        public string Destination { get; set; }
        public string DriverId { get; set; }
        public string NoOfItem { get; set; }
        public string Origin { get; set; }
        public string PaymentId { get; set; }
        public string PaymentStatus { get; set; }
        public string Price { get; set; }
        public string RequestTime { get; set; }
        public string Status { get; set; }
        public string Weight { get; set; }        
        public string MinPrice { get; set; }
        public string MaxPrice { get; set; }
        public string FinalPrice { get; set; }
        public string DriverPrice { get; set; }

    }
}