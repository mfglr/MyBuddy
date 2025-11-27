using MediaService.Domain;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace MediaService.Infrastructure
{
    internal class MongoContext
    {
        public IMongoClient Client { get; set; }
        public IMongoCollection<Media> Media { get; set; }

        public MongoContext(IConfiguration configuration)
        {
            Client = new MongoClient(configuration["MongoDbSettings:ConnectionString"]!);
            var database = Client.GetDatabase(configuration["MongoDbSettings:DatabaseName"]!);
            Media = database.GetCollection<Media>("media");
        }

    }
}
