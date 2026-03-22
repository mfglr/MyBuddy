using MongoDB.Driver;
using UserQueryService.Shared.Model;

namespace UserQueryService.Shared.MongoDB
{
    public static class IndexCreator
    {
        public static void Create(MongoContext context)
        {
            List<CreateIndexModel<User>> indexes = [
                new (Builders<User>.IndexKeys.Ascending(x => x.Name).Descending(x => x.Id)),
                new (Builders<User>.IndexKeys.Ascending(x => x.UserName).Descending(x => x.Id))
            ];
            context.Users.Indexes.CreateMany(indexes);
        }
    }
}
