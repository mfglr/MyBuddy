using Microsoft.EntityFrameworkCore;
using PostLikeQueryService.Domain.PostLikeAggregate;

namespace PostLikeQueryService.Infrastructure.PostgreSql
{
    internal class PostLikeRepository(SqlContext context) : IPostLikeRepository
    {
        public async Task CreateAsync(PostLike like, CancellationToken cancellationToken = default) =>
            await context.PostLikes.AddAsync(like, cancellationToken);

        public void Delete(PostLike like) =>
            context.PostLikes.Remove(like);

        public void Delete(IEnumerable<PostLike> likes) =>
            context.PostLikes.RemoveRange(likes);

        public Task<PostLike?> GetAsync(Guid postId, Guid userId, CancellationToken cancellationToken = default) =>
            context.PostLikes.FirstOrDefaultAsync(x => x.PostId == postId && x.UserId == userId, cancellationToken);

        public Task<List<PostLike>> GetByPostIdAsync(Guid postId, CancellationToken cancellationToken = default) =>
            context.PostLikes.Where(x => x.PostId == postId).ToListAsync(cancellationToken);
    }
}
