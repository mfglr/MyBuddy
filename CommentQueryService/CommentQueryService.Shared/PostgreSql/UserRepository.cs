using CommentQueryService.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace CommentQueryService.Shared.PostgreSql
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
                        ""Version"" = EXCLUDED.""Version"",
                        ""Name"" = EXCLUDED.""Name"",
                        ""UserName"" = EXCLUDED.""UserName"",
                        ""Media"" = EXCLUDED.""Media""
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
