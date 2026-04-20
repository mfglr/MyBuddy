using CommentQueryService.Domain.CommentAggregate;
using CommentQueryService.Domain.UserAggregate;
using MongoDB.Driver;

namespace CommentQueryService.Infrastructure.MongoDB
{
    internal class MongoContext(IMongoDatabase database)
    {
        public IMongoCollection<Comment> Comments => database.GetCollection<Comment>("Comments");
        public IMongoCollection<User> Users => database.GetCollection<User>("users");
    }
}
