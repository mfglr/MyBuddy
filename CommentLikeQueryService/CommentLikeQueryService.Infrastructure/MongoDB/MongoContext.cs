using CommentLikeQueryService.Domain;
using MongoDB.Driver;

namespace CommentLikeQueryService.Infrastructure.MongoDB
{
    internal class MongoContext(IMongoDatabase database)
    {
        public IMongoCollection<CommentLikeProjection> CommentLikes = database.GetCollection<CommentLikeProjection>("CommentLikes");
    }
}
