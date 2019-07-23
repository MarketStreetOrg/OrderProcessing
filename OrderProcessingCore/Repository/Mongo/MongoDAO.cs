using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using OrderProcessing.Database.Mongo;
using OrderProcessing.Database.Source;
using OrderProcessingCore.Utilities.Configurations;

namespace OrderProcessing.Database
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
