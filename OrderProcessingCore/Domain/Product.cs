namespace OrderProcessing.Domain
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }      
        public string SKU { get; set; }
        public Price price { get; set; }
        public int Quantity { get; set; }

        public class Builder
        {
            private Product product = new Product();

            public Builder SetName(string Name)
            {
                product.Name = Name;

                return this;
            }

            public Builder SetDescription(string Description)
            {
                product.Description = Description;

                return this;
            }

            public Builder SetSKU(string SKU)
            {
                product.SKU = SKU;

                return this;
            }

            public Builder SetQuantity(int Quantity)
            {
                product.Quantity = Quantity;

                return this;
            }


            public Product Build()
            {
                return product;
            }
        }
    }
}