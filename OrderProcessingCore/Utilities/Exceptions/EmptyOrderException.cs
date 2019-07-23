using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderProcessing.Utilities.Exceptions
{
    public class EmptyOrderException : Exception
    {
        public EmptyOrderException() : base("Order is empty")
        {
            
        }
    }
}