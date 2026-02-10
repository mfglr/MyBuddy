using MessageService.Domain.ConnectionAggregate;
using MessageService.Domain.MessageAggregate;
using MessageService.Domain.MessageDeliveryAggregate;
using MessageService.Domain.MessageReadReceiptAggregate;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace MessageService.Infrastructure.MongoDB
{
    internal class MongoContext
    {
        public IMongoClient Client { get; private set; }
        public IMongoCollection<Message> Messages { get; private set; }
        public IMongoCollection<Connection> Connections { get; private set; }
        public IMongoCollection<MessageDelivery> MessageDeliveries { get; private set; }
        public IMongoCollection<MessageReadReceipt> MessageReadReceipts { get; private set; }

        public MongoContext(IConfiguration configuration)
        {
            Client = new MongoClient(configuration["MongoDbSettings:ConnectionString"]);
            var database = Client.GetDatabase(configuration["MongoDbSettings:DatabaseName"]);
            Messages = database.GetCollection<Message>("messages");
            Connections = database.GetCollection<Connection>("connections");
            MessageDeliveries = database.GetCollection<MessageDelivery>("messageDeliveries");
            MessageReadReceipts = database.GetCollection<MessageReadReceipt>("messageReadReceipts");
        }
    }
}
