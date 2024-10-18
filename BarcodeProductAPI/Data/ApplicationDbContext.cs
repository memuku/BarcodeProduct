using BarcodeProductAPI.Entities;
using MongoDB.Driver;

namespace YourProject.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
            _database = client.GetDatabase(configuration["MongoDB:DatabaseName"]);
        }

        public IMongoCollection<Product> Products => _database.GetCollection<Product>("Products");
    }
}
