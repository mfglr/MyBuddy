using Microsoft.EntityFrameworkCore;
using PostQueryService.Shared.Model;

namespace PostQueryService.Shared.PostgreSql
{
    internal class PostRepository(SqlContext context) : IPostRepository
    {
        public async Task UpsertAsync(Post post, CancellationToken cancellationToken)
        {
            if (!await context.Posts.AnyAsync(x => x.Id == post.Id, cancellationToken: cancellationToken))
            {
                await context.Posts.AddAsync(post, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
                return;
            }
            await context.Posts
                .Where(x => x.Id == post.Id && x.Version < post.Version)
                .ExecuteUpdateAsync(
                    setters => setters
                        .SetProperty(x => x.UpdatedAt, post.UpdatedAt)
                        .SetProperty(x => x.Version, post.Version)
                        .SetProperty(x => x.Content.Value, post.Content?.Value)
                        .SetProperty(x => x.Content.ModerationResult.Sexual, post.Content?.ModerationResult?.Sexual)
                        .SetProperty(x => x.Content.ModerationResult.Hate, post.Content?.ModerationResult?.Hate)
                        .SetProperty(x => x.Content.ModerationResult.SelfHarm, post.Content?.ModerationResult?.SelfHarm)
                        .SetProperty(x => x.Content.ModerationResult.Violence, post.Content?.ModerationResult?.Violence)
                        .SetProperty(x => x.Media, post.Media),
                    cancellationToken
                );
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

        public Task<Post?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
            context.Posts.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
