using Microsoft.Extensions.Configuration;

namespace OrderProcessingCore.Utilities.Configurations
{
    public class AppConfigurations
    {
        private static IConfiguration Configuration;

        public static IConfiguration GetConfigurations()
        {
            return Configuration;
        }

        public static void SetConfigurations(IConfiguration configuration)
        {
            Configuration = configuration;
        }

    }
}
