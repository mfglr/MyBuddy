using MongoDB.Driver;
using UserQueryService.Shared.Model;

namespace UserQueryService.Shared.MongoDB
{
    public class MongoContext(IMongoDatabase database)
    {
        public IMongoCollection<User> Users = database.GetCollection<User>("Users");
    }
}
