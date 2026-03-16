using CommentService.Domain;
using MongoDB.Driver;

namespace CommentService.Infrastructure.MongoDb
{
    public class MongoContext(IMongoDatabase database)
    {
        public IMongoCollection<Comment> Comments = database.GetCollection<Comment>("Comments");
    }
}
