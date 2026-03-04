using MongoDB.Driver;
using PostService.Domain;

namespace PostService.Infrastructure.MongoDB
{
    internal class MongoContext(IMongoDatabase database)
    {
        public IMongoCollection<Post> Posts = database.GetCollection<Post>("Posts");
    }
}
