using CommentQueryService.Domain.UserAggregate;
using MongoDB.Driver;

namespace CommentQueryService.Infrastructure.MongoDB
{
    internal class UserRepository(MongoContext context) : IUserRepository
    {
        public Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Id, id);
            return context.Users.Find(filter).FirstOrDefaultAsync(cancellationToken);
        }

        public Task CreateAsync(User user, CancellationToken cancellationToken) =>
            context.Users.InsertOneAsync(user,cancellationToken: cancellationToken);

        public Task UpdateAsync(User user, CancellationToken cancellationToken)
        {
            var filter =
                Builders<User>.Filter.Eq(x => x.Id, user.Id) &
                Builders<User>.Filter.Lt(x => x.Version, user.Version);
            return context.Users.ReplaceOneAsync(filter,user,cancellationToken: cancellationToken);
        }
    }
}
