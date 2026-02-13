using Microsoft.EntityFrameworkCore;
using PostLikeQueryService.Domain.UserAggregate;

namespace PostLikeQueryService.Infrastructure.PostgreSql
{
    internal class UserRepository(SqlContext context) : IUserRepository
    {
        public Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task CreateAsync(User user, CancellationToken cancellationToken = default) =>
            await context.Users.AddAsync(user, cancellationToken);

        public void Delete(User user) =>
            context.Users.Remove(user);
    }
}
