using OrderProcessing.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderProcessing.Domain
{
    public class Order
    {
        public string OrderNumber { get;}
        public string CustomerNumber { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<Product> Products { get; set; }  
        public DateTime DateCreated { get; set; }
    }
}