using Microsoft.EntityFrameworkCore;
using PostQueryService.Domain.UserDomain;

namespace PostQueryService.Infrastructure.MsSql
{
    internal class UserRepository(MsSqlContext context) : IUserRepository
    {
        public async Task CreateAsync(User user, CancellationToken cancellationToken) =>
            await context.Users.AddAsync(user,cancellationToken);

        public void Delete(User user) =>
            context.Users.Remove(user);

        public Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
            context.Users.FirstOrDefaultAsync(x => x.Id == id,cancellationToken);
    }
}
