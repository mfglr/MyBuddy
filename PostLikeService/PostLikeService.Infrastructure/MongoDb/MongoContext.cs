using MongoDB.Driver;
using PostLikeService.Domain;

namespace PostLikeService.Infrastructure.MongoDb
{
    internal class MongoContext(IMongoDatabase database)
    {
        public IMongoCollection<PostLike> PostLikes = database.GetCollection<PostLike>("PostLikes");
    }
}
