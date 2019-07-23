using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OrderProcessingUnitTests
{
    [TestClass]
    public class OrderController
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
                                 .SetQuantity(12)
                                 .Build();

            Product product2 = new Product.Builder()
                                 .SetSKU(SKU2)
                                 .SetQuantity(4)
                                 .Build();

            Order order = new Order();
            order.Products.Add(product1);
            order.Products.Add(product2);
            order.CustomerNumber = "1234";

            OrderService.Save(order);

        }

        [TestMethod]
        public void TestUpdateOrder()
        {
            string SKU = "123123";

            Product product = new Product.Builder()
                    .SetSKU(SKU)
                    .SetQuantity(5)
                    .Build();

            Order order = new Order();
            order.Products.Add(product);
            order.CustomerNumber = "1234";
            order.DateCreated = DateTime.Now;
            order.OrderStatus = OrderStatus.CREATED.ToString();
            order.OrderNumber = "00000006";

            if (OrderService.Exists(order)) OrderService.Update(order);

        }

        [TestMethod]
        public void TestOrderExists()
        {
            string SKU = "123123";

            Product product = new Product.Builder()
                   .SetSKU(SKU)
                   .SetQuantity(4)
                   .Build();

            Order order = new Order();
            order.Products.Add(product);
            order.CustomerNumber = "1234";
            order.DateCreated = DateTime.Now;
            order.OrderStatus = OrderStatus.CREATED.ToString();
            order.OrderNumber = "00000006";

            Assert.AreEqual(true, OrderService.Exists(order));
        }

        [TestMethod]
        public void TestDeleteOrder()
        {
            string OrderNumber = "00000006";

            OrderService.Delete(OrderNumber);
        }

        [TestMethod]
        public void TestGetSingleOrder()
        {
            Assert.IsNotNull(OrderService.GetSingle("00000013"));
        }
    }
}
