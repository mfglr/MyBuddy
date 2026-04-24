using CommentLikeQueryService.Domain.CommentLikeAggregate;
using CommentLikeQueryService.Domain.UserAggregate;
using MongoDB.Driver;

namespace CommentLikeQueryService.Infrastructure.MongoDB
{
    internal class MongoContext(IMongoDatabase database)
    {
        public IMongoCollection<CommentLike> CommentLikes = database.GetCollection<CommentLike>("CommentLikes");
        public IMongoCollection<User> Users = database.GetCollection<User>("Users");
    }
}
