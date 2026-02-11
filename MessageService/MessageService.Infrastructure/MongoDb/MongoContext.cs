using MessageService.Domain;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace MessageService.Infrastructure.MongoDb
{
    internal class MongoContext
    {
        public IMongoClient Client { get; private set; }
        public IMongoDatabase Database { get; private set; }
        public IMongoCollection<Message> Messages { get; private set; }

        public MongoContext(IConfiguration configuration)
        {
            Client = new MongoClient(configuration["MongoDbSettings:ConnectionString"]);
            Database = Client.GetDatabase(configuration["MongoDbSettings:DatabaseName"]);
            Messages = Database.GetCollection<Message>("messages");
        }

    }
}
