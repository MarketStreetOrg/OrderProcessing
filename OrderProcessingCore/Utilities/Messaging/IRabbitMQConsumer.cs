using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessingCore.Utilities.Messaging
{
    public interface IRabbitMQConsumer
    {
        void ReceiveAsync();
    }
}
