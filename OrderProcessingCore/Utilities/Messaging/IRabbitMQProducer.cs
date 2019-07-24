using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderProcessingCore.Utilities.Messaging
{
    public interface IRabbitMQProducer
    {
        void Send(string msg, string Routingkey);
        void Send(object obj, string Routingkey);
        void Send(object obj, string Queue, string RoutingKey);

    }
}