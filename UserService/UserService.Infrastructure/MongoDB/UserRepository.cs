using MassTransit.MongoDbIntegration;
using MongoDB.Driver;
using UserService.Domain;

namespace UserService.Infrastructure.MongoDB
{
    internal class UserRepository(MongoContext context, MongoDbContext mongoDbContext) : IUserRepository
    {
        public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await context.Users.FindAsync(Builders<User>.Filter.Eq(x => x.Id, id), cancellationToken: cancellationToken);
            return await result.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> ExistAsync(UserName userName, CancellationToken cancellationToken)
        {
            var filter = Builders<User>.Filter.Eq(x => x.UserName, userName);
            var result = await context.Users.FindAsync(filter, cancellationToken: cancellationToken);
            return await result.AnyAsync(cancellationToken);
        }

        public Task CreateAsync(User user, CancellationToken cancellationToken) =>
            context.Users.InsertOneAsync(mongoDbContext.Session, user, cancellationToken: cancellationToken);

        public async Task UpdateAsync(User user, CancellationToken cancellationToken)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Id, user.Id) & Builders<User>.Filter.Eq(x => x.Version, user.Version - 1);
            var result = await context.Users.ReplaceOneAsync(mongoDbContext.Session, filter, user, cancellationToken: cancellationToken);
            if (result.ModifiedCount < 1)
                throw new ConflictDetectedException();
        }

        public Task DeleteAsync(User post, CancellationToken cancellationToken) =>
            context.Users.DeleteOneAsync(
                mongoDbContext.Session,
                Builders<User>.Filter.Eq(x => x.Id, post.Id),
                cancellationToken: cancellationToken
            );

        
    }
}
