using NUnit.Framework;
using OrderProcessingCore.Database.Sql.Implementation;
using OrderProcessingCore.Domain;
using OrderProcessingCore.Service;
using OrderProcessingCore.Utilities;
using System;

namespace OrderProcessingUnitTests
{
    public class OrderController
    {

        IOrderService OrderService = new OrderService(new OrderSqlDao());

        public OrderController()
        {

        }

        [SetUp]
        public void doFirst()
        {

        }

        [Test]
        public void GetAllTest()
        {
            Assert.IsNotNull(OrderService.GetAll());
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public void TestDeleteOrder()
        {
            string OrderNumber = "00000006";

            OrderService.Delete(OrderNumber);
        }

        [Test]
        public void TestGetSingleOrder()
        {
            Assert.IsNotNull(OrderService.GetSingle("00000013"));
        }
    }
}
