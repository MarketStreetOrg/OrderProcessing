namespace OrderProcessing.Domain
{
    public class Price
    {
        
        public Product product { get; set; }
        public double previous { get; set; }
        public double current { get; set; }

        public Price(double prev,double current)
        {
            this.current = current;
            previous = prev;
        }

        public Price()
        {
            
        }

    }
}