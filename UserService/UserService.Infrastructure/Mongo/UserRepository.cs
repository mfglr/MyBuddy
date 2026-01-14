using UserService.Domain;

namespace UserService.Infrastructure.Mongo
{
    public class UserRepository(MongoContext context) : IUserRepository
    {
        private readonly MongoContext _context = context;

        public Task CreateUserAsync(User user, CancellationToken cancellationToken)
            => _context.Users.InsertOneAsync(user, cancellationToken: cancellationToken);
    }
}
