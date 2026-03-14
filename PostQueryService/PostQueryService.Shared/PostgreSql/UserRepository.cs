using Microsoft.EntityFrameworkCore;
using PostQueryService.Shared.Model;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace PostQueryService.Shared.PostgreSql
{
    internal class UserRepository(SqlContext context) : IUserRepository
    {
        public Task<int> UpsertAsync(User user, CancellationToken cancellationToken)
        {
            var media = JsonSerializer.Serialize(user.Media);
            var sql = FormattableStringFactory.Create(
                @"
                    INSERT INTO ""Users"" AS u
                    (
                        ""Id"",
                        ""Version"",
                        ""Name"",
                        ""UserName"",
                        ""Media""
                    )
                    VALUES ({0}, {1}, {2}, {3}, {4}::jsonb)
                    ON CONFLICT (""Id"")
                    DO UPDATE SET
                         ""Id"" = {0},
                        ""Version"" = {1},
                        ""Name"" = {2},
                        ""UserName"" = {3},
                        ""Media"" = {4}::jsonb
                    WHERE u.""Id"" = {0} and u.""Version"" < {1};
                ",
                user.Id,
                user.Version,
                user.Name,
                user.UserName,
                media
            );
            return context.Database.ExecuteSqlAsync(sql, cancellationToken);
        }
    }
}
