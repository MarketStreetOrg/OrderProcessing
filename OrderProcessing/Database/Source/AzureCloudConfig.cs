using OrderProcessing.Utilities;
using System;
using System.Configuration;

namespace OrderProcessing.Database.Source
{
    public class AzureCloudConfig : IConfig
    {

        private string CloudConnectionString;

        public AzureCloudConfig()
        {
            LoadConfigurations();
        }

        public string GetConnectionString()
        {
             return CloudConnectionString;
         
        }

        public void LoadConfigurations()
        {
            string cs=ConfigurationManager.ConnectionStrings["kataledatabaseazure"].ConnectionString.ToString();

            IniFile InitializationFile = new IniFile(ConfigurationManager.AppSettings["IniPath"]);

            InitializationFile.Write("key", "values");

            string UserName = InitializationFile.Read("username");
            string Password = InitializationFile.Read("Password");

            CloudConnectionString = String.Format(cs, UserName, Password);

        }
    }
}