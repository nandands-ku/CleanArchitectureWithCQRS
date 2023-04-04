using DiziCashier.Core.Entities;
using DiziCashier.Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DiziCashier.Infrastructure.Data
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database = null;
        public MongoDBContext(IOptions<DiziCashierMongoDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            if (mongoClient != null)
                _database = mongoClient.GetDatabase(settings.Value.DatabaseName);
        }
        public IMongoCollection<ItemCategory> ItemCategories
        {
            get
            {
                return _database.GetCollection<ItemCategory>("ItemCategory");
            }
        }
    }
}
