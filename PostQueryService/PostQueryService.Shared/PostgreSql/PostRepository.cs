using Microsoft.EntityFrameworkCore;
using PostQueryService.Shared.Model;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace PostQueryService.Shared.PostgreSql
{
    internal class PostRepository(SqlContext context) : IPostRepository
    {
        public Task<int> UpsertAsync(Post post, CancellationToken cancellationToken)
        {
            var media = JsonSerializer.Serialize(post.Media);
            var contentModerationResult = post.Content != null ? JsonSerializer.Serialize(post.Content.ModerationResult) : null;
            var sql = FormattableStringFactory.Create(
                @"
                    INSERT INTO ""Posts""  AS p
                    (
                        ""Id"",
                        ""CreatedAt"",
                        ""UpdatedAt"",
                        ""DeletedAt"",
                        ""IsDeleted"",
                        ""Version"",
                        ""UserId"",
                        ""Content_Value"",
                        ""Content_ModerationResult"",
                        ""Media"",
                        ""LikeCount"",
                        ""CommentCount""
                    )
                    VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}::jsonb, {9}::jsonb, {10}, {11})
                    ON CONFLICT (""Id"")
                    DO UPDATE SET
                        ""UpdatedAt"" = {2},
                        ""DeletedAt"" = {3},
                        ""IsDeleted"" = {4},
                        ""Version"" = {5},
                        ""Content_Value"" = {7},
                        ""Content_ModerationResult"" = {8}::jsonb,
                        ""Media"" = {9}::jsonb
                    WHERE p.""Id"" = {0} and p.""Version"" < {5};
                ",
                post.Id,
                post.CreatedAt,
                post.UpdatedAt,
                post.DeletedAt,
                post.IsDeleted,
                post.Version,
                post.UserId,
                post.Content?.Value,
                contentModerationResult,
                media,
                post.LikeCount,
                post.CommentCount
            );
            return context.Database.ExecuteSqlAsync(sql, cancellationToken);
        }

        public Task<int> IncreaseLikeCount(Guid id, CancellationToken cancellationToken) =>
            context.Posts
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(
                    setters => setters
                        .SetProperty(x => x.LikeCount, x => x.LikeCount + 1),
                    cancellationToken
                );

        public Task<int> DecreaseLikeCount(Guid id, CancellationToken cancellationToken) =>
            context.Posts
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(
                    setters => setters
                        .SetProperty(x => x.LikeCount, x => x.LikeCount - 1),
                    cancellationToken
                );

        public Task<int> IncreaseCommentCount(Guid id, CancellationToken cancellationToken) =>
            context.Posts
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(
                    setters => setters
                        .SetProperty(x => x.CommentCount, x => x.CommentCount + 1),
                    cancellationToken
                );

        public Task<int> DecreaseCommentCount(Guid id, CancellationToken cancellationToken) =>
            context.Posts
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(
                    setters => setters
                        .SetProperty(x => x.CommentCount, x => x.CommentCount - 1),
                    cancellationToken
                );
    }
}
