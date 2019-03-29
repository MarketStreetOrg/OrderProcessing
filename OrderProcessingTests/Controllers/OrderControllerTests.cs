using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderProcessing.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Controllers.Tests
{
    [TestClass()]
    public class OrderControllerTests
    {
        IOrderService OrderService = new OrderService();

        [TestMethod()]
        public void GetAllTest()
        {
            

            Assert.Fail();
        }
    }
}