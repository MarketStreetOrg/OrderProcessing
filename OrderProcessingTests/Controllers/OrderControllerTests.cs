using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderProcessing.Controllers;
using OrderProcessing.Domain;
using OrderProcessing.Service;
using OrderProcessing.Utilities;
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
            Assert.IsNotNull(OrderService.GetAll());           
        }
        
        [TestMethod]
        public void TestSaveOrder()
        {

            string SKU = "123123";
            string SKU2 = "235456";

            Product product1 = new Product.Builder()
                                 .SetSKU(SKU)
                                 .Build();

            Product product2 = new Product.Builder()
                                 .SetSKU(SKU2)
                                 .Build();

            Order order = new Order();
            order.Items = new Dictionary<Product, int>();
            order.Items.Add(product1,12);
            order.Items.Add(product2, 4);
            order.CustomerNumber = "1234";

            OrderService.Save(order);
            
        }

        [TestMethod]
        public void TestUpdateOrder()
        {
            string SKU = "123123";

            Product product = new Product.Builder()
                    .SetSKU(SKU)
                    .Build();

            Order order = new Order();
            order.Items = new Dictionary<Product, int>();
            order.Items.Add(product, 5);
            order.CustomerNumber = "1234";
            order.DateCreated = DateTime.Now;
            order.OrderStatus = OrderStatus.CREATED.ToString();
            order.OrderNumber = "00000006";

            if(OrderService.Exists(order))OrderService.Update(order);

        }

        [TestMethod]
        public void TestOrderExists()
        {
            string SKU = "123123";

            Product product = new Product.Builder()
                   .SetSKU(SKU)
                   .Build();

            Order order = new Order();
            order.Items = new Dictionary<Product, int>();
            order.Items.Add(product, 5);
            order.CustomerNumber = "1234";
            order.DateCreated = DateTime.Now;
            order.OrderStatus = OrderStatus.CREATED.ToString();
            order.OrderNumber = "00000006";

            Assert.AreEqual(true, OrderService.Exists(order));
        }

    }
}