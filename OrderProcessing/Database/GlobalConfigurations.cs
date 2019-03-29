using OrderProcessing.Database.Source;

namespace OrderProcessing.Database
{
    public class GlobalConfigurations
    {

        public static IConfig Configuration { get; set; }
        

        public static string ConnectionString
        {
            get
            {
                return Configuration.GetConnectionString();

            }
        }
    }
}