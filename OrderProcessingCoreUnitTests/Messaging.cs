using NUnit.Framework;
using OrderProcessingCore.Utilities.Messaging;
using OrderProcessingCore.Utilities.Messaging.implementation;


namespace OrderProcessingCoreUnitTests
{

    class Messaging
    {

        private IRabbitMQProducer rabbitMQProducer = new TopicRabbitMQProducer("fulfillment", "ordersQueue");

        [Test]
        public void TestSendOrder()
        {
            rabbitMQProducer.Send("2323239", "fulfillment.orders");
        }

    }


   
}
