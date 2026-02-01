using Microsoft.EntityFrameworkCore;
using PostQueryService.Application.QueryRepositories;

namespace PostQueryService.Infrastructure.MsSql.QuerRepositories
{
    internal class PostQueryRepository(MsSqlContext context, PostResponseMapper mapper) : IPostQueryRepository
    {
        public async Task<IEnumerable<PostResponse>> GetPostsByUserId(Guid userId, Page page, CancellationToken cancellationToken)
        {
            var posts = await context.Posts
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .ToPage(page)
                .ToInternalPostResponse(context)
                .ToListAsync(cancellationToken);
            return posts.Select(mapper.ToPostResponse);
        }
    }
}
