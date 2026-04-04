using MongoDB.Driver;
using PostLikeQueryService.Domain.UserAggregate;

namespace PostLikeQueryService.Infrastructure.MongoDB
{
    internal class UserRepository(MongoContext context) : IUserRepository
    {
        public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Id, id);
            var result = await context.Users.FindAsync(filter, cancellationToken: cancellationToken);
            return await result.FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }

        public Task CreateAync(User user, CancellationToken cancellationToken) =>
            context.Users.InsertOneAsync(user,cancellationToken: cancellationToken);

        public async Task UpdateAsync(User user, CancellationToken cancellationToken)
        {
            var filter =
                Builders<User>.Filter.Eq(x => x.Id, user.Id) &
                Builders<User>.Filter.Lt(x => x.Version, user.Version);
            var result = await context.Users.ReplaceOneAsync(filter, user, cancellationToken: cancellationToken);
        }
    }
}
