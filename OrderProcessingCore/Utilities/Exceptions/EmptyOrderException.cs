using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderProcessingCore.Utilities.Exceptions
{
    public class EmptyOrderException : Exception
    {
        public EmptyOrderException() : base("Order is empty")
        {
            
        }
    }
}