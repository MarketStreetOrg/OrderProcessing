using Microsoft.Extensions.Configuration;
using OrderProcessingCore.Utilities;
using OrderProcessingCore.Utilities.Configurations;
using System;

namespace OrderProcessingCore.Database.Source
{
    public class AzureCloudConfig
    {
       
        //private string CloudConnectionString;

        //public AzureCloudConfig()
        //{
        //    LoadConfigurations();
        //}

        //public override string GetConnectionString()
        //{
        //    return CloudConnectionString;

        //}

        //public override void LoadConfigurations()
        //{
        //    string cs = configuration.GetConnectionString("kataledatabaseazure").ToString();

        //    string iniFile = configuration.GetSection("StaticFiles").GetValue<string>("IniPath");

        //    IniFile InitializationFile = new IniFile(iniFile);

        //    InitializationFile.Write("key", "values");

        //    string UserName = InitializationFile.Read("username");
        //    string Password = InitializationFile.Read("Password");

        //    CloudConnectionString = String.Format(cs, UserName, Password);

        //}
    }
}