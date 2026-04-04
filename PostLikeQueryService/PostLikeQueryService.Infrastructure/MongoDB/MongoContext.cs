using MongoDB.Driver;
using PostLikeQueryService.Domain.UserAggregate;

namespace PostLikeQueryService.Infrastructure.MongoDB
{
    internal class MongoContext(IMongoDatabase database)
    {
        public IMongoCollection<User> Users = database.GetCollection<User>("Users");
    }
}
