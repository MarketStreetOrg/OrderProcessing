using OrderProcessing.Domain;
using OrderProcessing.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OrderProcessing.Controllers
{
    [RoutePrefix("Order")]
    public class OrderController : ApiController
    {
        IOrderService OrderService = new OrderService();

        [Route("orders")]
        public List<Order> GetAll()
        {
            return OrderService.GetAll();
        }

    }
}