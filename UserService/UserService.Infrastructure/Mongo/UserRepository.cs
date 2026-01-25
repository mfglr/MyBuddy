using MongoDB.Driver;
using UserService.Domain;

namespace UserService.Infrastructure.Mongo
{
    public class UserRepository(MongoContext context) : IUserRepository
    {
        private readonly MongoContext _context = context;

        public Task CreateUserAsync(User user, CancellationToken cancellationToken)
            => _context.Users.InsertOneAsync(user, cancellationToken: cancellationToken);

        public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, id);
            var document = await _context.Users.FindAsync(filter, cancellationToken: cancellationToken);
            return  await document.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task UpdateAsync(User user, CancellationToken cancellationToken)
        {
            var filter = Builders<User>.Filter.And(
                Builders<User>.Filter.Eq(c => c.Id, user.Id),
                Builders<User>.Filter.Eq(c => c.Version, user.Version - 1)
            );
            var result = await _context.Users.ReplaceOneAsync(filter, user, cancellationToken: cancellationToken);
            if (result.ModifiedCount == 0)
                throw new AppConcurrencyException();
        }
    }
}
