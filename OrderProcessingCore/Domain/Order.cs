using Newtonsoft.Json;
using OrderProcessing.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderProcessing.Domain
{
    public class Order
    {
        public string OrderNumber { get; set; }
        public string CustomerNumber { get; set; }
        public string OrderStatus { get; set; }
        public HashSet<Product> Products { get; set; } = new HashSet<Product>();

        public DateTime DateCreated { get; set; }

        public class Builder
        {
            Order order = new Order();

            public Builder()
            {
                order.Products = new HashSet<Product>();
            }

            public Builder setOrderNumber(string OrderNumber)
            {
                order.OrderNumber = OrderNumber;
                return this;
            }
            public Builder setCustomerNumber(string customerNumber)
            {
                order.CustomerNumber = customerNumber;
                return this;
            }

            public Builder setStatus(string orderStatus)
            {
                order.OrderStatus = orderStatus.ToString();
                return this;
            }

            public Builder addItem(string sku, int quantity)
            {

                Product product = new Product.Builder()
                                    .SetSKU(sku)
                                    .SetQuantity(quantity)
                                    .Build();

                order.Products.Add(product);

                return this;
            }

            public Builder setDate(DateTime date)
            {
                order.DateCreated = date;
                return this;
            }

            public Order Build()
            {
                return order;
            }

        }
    }
}