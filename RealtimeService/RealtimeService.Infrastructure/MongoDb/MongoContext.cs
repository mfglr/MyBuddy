using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using RealtimeService.Domain;

namespace RealtimeService.Infrastructure.MongoDb
{
    internal class MongoContext
    {
        public IMongoClient Client { get; private set; }
        public IMongoDatabase Database { get; private set; }
        public IMongoCollection<Connection> Connections { get; private set; }

        public MongoContext(IConfiguration configuration)
        {
            Client = new MongoClient(configuration["MongoDbSettings:ConnectionString"]);
            Database = Client.GetDatabase(configuration["MongoDbSettings:DatabaseName"]);
            Connections = Database.GetCollection<Connection>("connections");
        }

    }
}
