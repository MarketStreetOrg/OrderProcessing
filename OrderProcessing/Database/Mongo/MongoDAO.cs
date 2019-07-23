using MongoDB.Driver;
using OrderProcessing.Database.Mongo;
using OrderProcessing.Database.Source;

namespace OrderProcessing.Database
{
    public abstract class MongoDAO
    {
        public MongoClient mongoClient { get; }
        public IMongoDatabase mongoDB { get; }
        public MongoDAO()
        {
            GlobalConfigurations.Configuration = new LocalMongoDBConfig();

            mongoClient = new MongoClient(GlobalConfigurations.ConnectionString);

            mongoDB = mongoClient.GetDatabase("Katale", null);
        }

    }
}
