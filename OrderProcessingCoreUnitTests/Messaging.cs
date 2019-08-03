using NUnit.Framework;
using OrderProcessingCore.Utilities.Messaging;
using OrderProcessingCore.Utilities.Messaging.implementation;
using System.Threading;

namespace OrderProcessingCoreUnitTests
{

    class Messaging
    {

        private IRabbitMQProducer rabbitMQProducer = new TopicRabbitMQProducer("fulfillment", "ordersQueue");

        [Test]
        public void TestSendOrder()
        {
            //for (int i = 0; i < 100000; i++)
            //{
                rabbitMQProducer.Send("1234567", "fulfillment.orders");
                //Thread.Sleep();
            //}
        }

    }


   
}
