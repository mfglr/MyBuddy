using Microsoft.EntityFrameworkCore;
using PostLikeQueryService.Application;

namespace PostLikeQueryService.Infrastructure.PostgreSql
{
    internal class PostLikeQueryRepository(SqlContext context, PostLikeResponseMapper mapper) : IPostLikeQueryRepository
    {
        public async Task<List<PostLikeResponse>> GetLikesByPostId(Guid postId, Guid? cursor = null, int recordsPerPage = 20, CancellationToken cancellationToken = default)
        {
            var likes = await context.PostLikes
                .AsNoTracking()
                .Where(x => x.PostId == postId && (cursor == null || x.Id < cursor))
                .OrderByDescending(x => x.Id)
                .Take(recordsPerPage)
                .ToPostLikeResponse(context)
                .ToListAsync(cancellationToken);
            return [.. likes.Select(mapper.Map)];
        }
    }
}
