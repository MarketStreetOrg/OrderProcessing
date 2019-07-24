using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using OrderProcessingCore.Database.Mongo;
using OrderProcessingCore.Database.Source;
using OrderProcessingCore.Utilities.Configurations;

namespace OrderProcessingCore.Database
{
    public abstract class MongoDAO
    {
        public MongoClient mongoClient { get; }
        public IMongoDatabase mongoDB { get; }

        private IConfiguration Configuration = AppConfigurations.GetConfigurations();

        public MongoDAO()
        {
            
            mongoClient = new MongoClient(Configuration.GetConnectionString("MongoDB"));

            mongoDB = mongoClient.GetDatabase("Katale", null);
        }

    }
}
