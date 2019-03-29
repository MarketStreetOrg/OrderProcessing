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
       
        [Route("all")]
        public string GetAll()
        {
            return "This is my initialized Controller";
        }

    }
}