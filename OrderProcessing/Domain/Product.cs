namespace OrderProcessing.Domain
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool PromoDept { get; set; }
        public bool PromoFront { get; set; }
        public bool InStock { get; set; }
      

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

            public Builder IsPromoDepartment(bool boolean)
            {
                product.PromoDept = boolean;

                return this;
            }

            public Builder IsPromoFront(bool boolean)
            {
                product.PromoFront = boolean;

                return this;
            }

            public Builder IsInStock(bool boolean)
            {
                product.InStock = boolean;

                return this;
            }


            public Product Build()
            {
                return product;
            }
        }
    }
}