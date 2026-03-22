using MongoDB.Bson;
using MongoDB.Driver;
using UserQueryService.Shared.Model;

namespace UserQueryService.Shared.MongoDB
{
    internal class UserRepository(MongoContext context) : IUserRepository
    {
        public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await context.Users.FindAsync(Builders<User>.Filter.Eq(x => x.Id, id), cancellationToken: cancellationToken);
            return await result.FirstOrDefaultAsync(cancellationToken);
        }

        public Task<List<User>> SearchAsync(string key, Guid? cursor, int pageSize, CancellationToken cancellationToken)
        {
            var searchFilter =
                Builders<User>.Filter.Regex(x => x.UserName, new BsonRegularExpression($"^{key}", "i")) |
                Builders<User>.Filter.Regex(x => x.Name, new BsonRegularExpression($"^{key}", "i"));
            var cursorFilter = Builders<User>.Filter.Lt(x => x.Id, cursor);
            var filter = cursor != null ? searchFilter & cursorFilter : searchFilter;
            
            return context.Users
                .Find(filter)
                .SortByDescending(x => x.Id)
                .Limit(pageSize)
                .ToListAsync(cancellationToken);
        }

        public Task UpsertAsync(User user, CancellationToken cancellationToken)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Id, user.Id) & Builders<User>.Filter.Lt(x => x.Version, user.Version);
            var options = new ReplaceOptions { IsUpsert = true };
            return context.Users.ReplaceOneAsync(filter, user, options, cancellationToken);
        }

        public Task IncreasePostCount(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Id, id);
            var update = Builders<User>.Update.Inc(x => x.PostCount, 1);
            return context.Users.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
        }

        public Task DecreasePostCount(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Id, id);
            var update = Builders<User>.Update.Inc(x => x.PostCount, -1);
            return context.Users.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
        }
    }
}
