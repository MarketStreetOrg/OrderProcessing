using OrderProcessingCore.Domain;
using OrderProcessingCore.Service;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using OrderProcessingCore.DAO;
using System.Threading.Tasks;

namespace OrderProcessingCore.Controllers
{
    [Route("Order")]
    public class OrderController : ControllerBase
    {
        IOrderService OrderService;

        string productService = "https://katale.azurewebsites.net/api";
        //string productService2 = "http://localhost:55246/api";

        public OrderController(IOrderService OrderService)
        {
            this.OrderService = OrderService;
        }
         
        [HttpGet]
        [Route("orders")]
        public List<Order> GetAll()
        {
            return OrderService.GetAll();
        }

        [HttpGet]
        [Route("get/{id?}")]
        public async Task<Order> GetSingle([FromQuery]string id)
        {
            var order=OrderService.GetSingle(id);

            HashSet<Product> products = new HashSet<Product>();

            await Task.Run(()=> order.Products.ToList().ForEach(p =>
              {
                  HttpClient client = new HttpClient();

                  var result = client.GetAsync(productService + "/product/product/" + p.SKU);

                  JObject obj = JObject.Parse(result.Result.Content.ReadAsStringAsync().Result);

                  Product pr = new Product.Builder()
                                             .SetName(obj["Name"].ToString())
                                             .SetDescription(obj["Description"].ToString())
                                             .SetQuantity(p.Quantity)
                                             .SetSKU(p.SKU)
                                             .Build();

                  products.Add(pr);

              }));

            order.Products = products;

            return order;
        }

        [HttpGet]
        [Route("/{id?}/items")]
        public List<Product> GetProducts([FromQuery] string id)
        {
            List<Product> productListing = new List<Product>();

            HttpClient client = new HttpClient();

            var listing = OrderService.GetSingle(id).Products.ToList();

            if (listing.Count != 0)
            {
                listing.ForEach(product =>
                {
                    var result = client.GetAsync(productService+"/product/product/"+product.SKU);

                    JObject obj = JObject.Parse(result.Result.Content.ReadAsStringAsync().Result);

                    Product p = new Product.Builder()
                                               .SetName(obj["Name"].ToString())
                                               .SetDescription(obj["Description"].ToString())
                                               .SetQuantity(product.Quantity)
                                               .SetSKU(product.SKU)
                                               .Build();

                   productListing.Add(p);

                });

            }
            return productListing;

        }

        [HttpDelete]
        [Route("get/{id?}/remove")]
        public string Delete([FromQuery] string id)
        {
            OrderService.Delete(id);

            return "Order has been removed";
        }

    }
}