using CommentLikeService.Domain;
using MongoDB.Driver;

namespace CommentLikeService.Infrastructure.MongoDb
{
    internal class MongoContext(IMongoDatabase database)
    {
        public IMongoCollection<CommentLike> CommentLikes = database.GetCollection<CommentLike>("CommentLikes");
    }
}
