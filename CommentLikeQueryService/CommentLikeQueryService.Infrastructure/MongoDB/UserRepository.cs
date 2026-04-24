using CommentLikeQueryService.Domain.UserAggregate;
using MongoDB.Driver;

namespace CommentLikeQueryService.Infrastructure.MongoDB
{
    internal class UserRepository(MongoContext context) : IUserRepository
    {
        public Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
            context.Users
                .Find(Builders<User>.Filter.Eq(x => x.Id, id))
                .FirstOrDefaultAsync(cancellationToken);

        public Task UpdateAsync(User user, CancellationToken cancellationToken)
        {
            var filter = 
                Builders<User>.Filter.Eq(x => x.Id, user.Id) &
                Builders<User>.Filter.Lt(x => x.Version, user.Version);
            return context.Users.ReplaceOneAsync(filter, user, cancellationToken: cancellationToken);
        }

        public Task CreateAsync(User user, CancellationToken cancellationToken) =>
            context.Users.InsertOneAsync(user, cancellationToken: cancellationToken);

        public Task DeleteAsync(User user, CancellationToken cancellationToken) =>
            context.Users.DeleteOneAsync(Builders<User>.Filter.Eq(x => x.Id, user.Id), cancellationToken: cancellationToken);
    }
}
