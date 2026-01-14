using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using UserService.Domain;

namespace UserService.Infrastructure.Mongo
{
    public class MongoContext
    {
        public IMongoClient Client { get; set; }
        public IMongoCollection<User> Users { get; set; }

        public MongoContext(IConfiguration configuration)
        {
            Client = new MongoClient(configuration["MongoDbSettings:ConnectionString"]!);
            var database = Client.GetDatabase(configuration["MongoDbSettings:DatabaseName"]!);
            Users = database.GetCollection<User>("users");
        }

    }
}
