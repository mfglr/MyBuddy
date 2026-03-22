using CommentQueryService.Domain;
using MongoDB.Driver;

namespace CommentQueryService.Infrastructure.MongoDB
{
    internal class MongoContext(IMongoDatabase database)
    {
        public IMongoCollection<CommentProjection> Comments => database.GetCollection<CommentProjection>("Comments"); 
    }
}
