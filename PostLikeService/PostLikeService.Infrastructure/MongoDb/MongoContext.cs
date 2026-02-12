using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using PostLikeService.Domain;

namespace PostLikeService.Infrastructure.MongoDb
{
    internal class MongoContext
    {
        public IMongoClient Client { get; private set; }
        public IMongoDatabase Database { get; private set; }
        public IMongoCollection<PostLike> PostLikes { get; private set; }

        public MongoContext(IConfiguration configuration)
        {
            Client = new MongoClient(configuration["MongoDbSettings:ConnectionString"]);
            Database = Client.GetDatabase(configuration["MongoDbSettings:DatabaseName"]);
            PostLikes = Database.GetCollection<PostLike>("postLikes");
        }

    }
}
