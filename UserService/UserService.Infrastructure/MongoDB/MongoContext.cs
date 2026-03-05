using MongoDB.Driver;
using UserService.Domain;

namespace UserService.Infrastructure.MongoDB
{
    internal class MongoContext(IMongoDatabase database)
    {
        public IMongoCollection<User> Users = database.GetCollection<User>("Users");
    }
}
