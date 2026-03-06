using Microsoft.EntityFrameworkCore;
using PostQueryService.Shared.Model;

namespace PostQueryService.Shared.PostgreSql
{
    internal class UserRepository(SqlContext context) : IUserRepository
    {
        public async Task UpsertAsync(User user, CancellationToken cancellationToken)
        {
            if(!await context.Users.AnyAsync(x => x.Id == user.Id, cancellationToken))
            {
                await context.Users.AddAsync(user, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
                return;
            }
            await context.Users
                .Where(x => x.Id == user.Id && x.Version < user.Version)
                .ExecuteUpdateAsync(
                    setters => setters
                        .SetProperty(x => x.Version, user.Version)
                        .SetProperty(x => x.UserName, user.UserName)
                        .SetProperty(x => x.Name, user.Name)
                        .SetProperty(x => x.Media, user.Media),
                    cancellationToken
                );
        }
    }
}
