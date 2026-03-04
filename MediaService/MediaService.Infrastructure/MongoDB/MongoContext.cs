using MediaService.Domain;
using MongoDB.Driver;

namespace MediaService.Infrastructure.MongoDB
{
    internal class MongoContext(IMongoDatabase database)
    {
        public IMongoCollection<Media> Media = database.GetCollection<Media>("Media");
    }
}
