using CommentQueryService.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace CommentQueryService.Shared.PostgreSql
{
    internal class CommentRepository(SqlContext context) : ICommentRepository
    {
        public Task<int> UpsertAsync(Comment comment, CancellationToken cancellationToken)
        {
            var contentModerationResult = comment.Content != null ? JsonSerializer.Serialize(comment.Content.ModerationResult) : null;
            var sql = FormattableStringFactory.Create(
                @"
                    INSERT INTO ""Comments"" AS c
                    (
                        ""Id"",
                        ""CreatedAt"",
                        ""UpdatedAt"",
                        ""DeletedAt"",
                        ""IsDeleted"",
                        ""Version"",
                        ""UserId"",
                        ""PostId"",
                        ""ParentId"",
                        ""RepliedId"",
                        ""Content_Value"",
                        ""Content_ModerationResult"",
                        ""ChildCount"",
                        ""LikeCount""
                    )
                    VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}::jsonb, {12}, {13})
                    ON CONFLICT (""Id"")
                    DO UPDATE SET
                        ""UpdatedAt"" = EXCLUDED.""UpdatedAt"",
                        ""DeletedAt"" = EXCLUDED.""DeletedAt"",
                        ""IsDeleted"" = EXCLUDED.""IsDeleted"",
                        ""Version"" = EXCLUDED.""Version"",
                        ""Content_Value"" = EXCLUDED.""Content_Value"",
                        ""Content_ModerationResult"" = EXCLUDED.""Content_ModerationResult""
                    WHERE c.""Id"" = {0} and c.""Version"" < {5};
                ",
                comment.Id,
                comment.CreatedAt,
                comment.UpdatedAt,
                comment.DeletedAt,
                comment.IsDeleted,
                comment.Version,
                comment.UserId,
                comment.PostId,
                comment.ParentId,
                comment.RepliedId,
                comment.Content?.Value,
                contentModerationResult,
                comment.ChildCount,
                comment.LikeCount
            );
            return context.Database.ExecuteSqlAsync(sql, cancellationToken);
        }

        public Task<int> IncreaseChildCount(Guid id, CancellationToken cancellationToken) =>
            context.Comments
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(
                    builder => builder.SetProperty(x => x.ChildCount,x => x.ChildCount + 1),
                    cancellationToken
                );
        public Task<int> DecreaseChildCount(Guid id, CancellationToken cancellationToken) =>
            context.Comments
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(
                    builder => builder.SetProperty(x => x.ChildCount, x => x.ChildCount - 1),
                    cancellationToken
                );

        public Task<int> IncreaseLikeCount(Guid id, CancellationToken cancellationToken) =>
            context.Comments
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(
                    builder => builder.SetProperty(x => x.LikeCount, x => x.LikeCount + 1),
                    cancellationToken
                );
        public Task<int> DecreaseLikeCount(Guid id, CancellationToken cancellationToken) =>
            context.Comments
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(
                    builder => builder.SetProperty(x => x.LikeCount, x => x.LikeCount - 1),
                    cancellationToken
                );
    }
}
