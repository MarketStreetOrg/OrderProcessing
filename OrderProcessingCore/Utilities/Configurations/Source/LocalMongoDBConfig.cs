using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using OrderProcessingCore.Utilities.Configurations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace OrderProcessing.Database.Source
{
    public class LocalMongoDBConfig
    {
        //public override string GetConnectionString()
        //{
        //    return configuration.GetConnectionString("MongoDB").ToString();
        //}

        //public override void LoadConfigurations()
        //{
        //    throw new NotImplementedException();
        //}
    }
}