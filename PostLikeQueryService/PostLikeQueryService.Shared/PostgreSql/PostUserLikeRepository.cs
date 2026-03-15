using Microsoft.EntityFrameworkCore;
using PostLikeQueryService.Shared.Model;
using System.Runtime.CompilerServices;

namespace PostLikeQueryService.Shared.PostgreSql
{
    internal class PostUserLikeRepository(SqlContext context) : IPostUserLikeRepository
    {
        public Task<int> UpsertAsync(PostUserLike postUserLike, CancellationToken cancellationToken)
        {
            var sql = FormattableStringFactory.Create(
                @"
                    INSERT INTO ""PostUserLikes"" AS pul
                    (
                        ""SequenceId"",
                        ""CreatedAt"",
                        ""IsDeleted"",
                        ""DeletedAt"",
                        ""Version"",
                        ""PostId"",
                        ""UserId""
                    )
                    VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6})
                    ON CONFLICT (""PostId"", ""SequenceId"", ""UserId"")
                    DO UPDATE SET
                        ""IsDeleted"" = EXCLUDED.""IsDeleted"",
                        ""DeletedAt"" = EXCLUDED.""DeletedAt"",
                        ""Version"" = EXCLUDED.""Version""
                    WHERE pul.""PostId"" = {5} and pul.""UserId"" = {6} and pul.""Version"" < {4};
                ",
                postUserLike.SequenceId,
                postUserLike.CreatedAt,
                postUserLike.IsDeleted,
                postUserLike.DeletedAt,
                postUserLike.Version,
                postUserLike.PostId,
                postUserLike.UserId
            );
            return context.Database.ExecuteSqlAsync(sql, cancellationToken);
        }
    }
}
