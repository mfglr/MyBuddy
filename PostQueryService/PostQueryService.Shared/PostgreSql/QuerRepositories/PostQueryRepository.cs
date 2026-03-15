using Microsoft.EntityFrameworkCore;
using PostQueryService.Shared.Model;

namespace PostQueryService.Shared.PostgreSql.QuerRepositories
{
    internal class PostQueryRepository(SqlContext context) : IPostQueryRepository
    {
        public Task<List<PostResponse>> GetByUserId(Guid userId, Guid? cursor, int pageSize, CancellationToken cancellationToken) =>
            context.Posts
                .AsNoTracking()
                .Where(x => x.UserId == userId && (cursor == null || x.Id < cursor))
                .OrderByDescending(x => x.Id)
                .Take(pageSize)
                .ToPostResponse(context)
                .ToListAsync(cancellationToken);
    }
}
