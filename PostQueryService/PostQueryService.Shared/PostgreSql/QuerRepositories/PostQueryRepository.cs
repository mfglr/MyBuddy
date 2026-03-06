using Microsoft.EntityFrameworkCore;
using PostQueryService.Shared.Model;

namespace PostQueryService.Shared.PostgreSql.QuerRepositories
{
    internal class PostQueryRepository(SqlContext context, PostResponseMapper mapper) : IPostQueryRepository
    {
        public async Task<List<PostResponse>> GetByUserId(Guid userId, Guid? cursor, int pageSize, CancellationToken cancellationToken)
        {
            var posts = await context.Posts
                .AsNoTracking()
                .Where(x => x.UserId == userId && (cursor == null || x.Id < cursor))
                .Take(pageSize)
                .ToInternalPostResponse(context)
                .ToListAsync(cancellationToken);
            return [.. posts.Select(mapper.ToPostResponse)];
        }
    }
}
