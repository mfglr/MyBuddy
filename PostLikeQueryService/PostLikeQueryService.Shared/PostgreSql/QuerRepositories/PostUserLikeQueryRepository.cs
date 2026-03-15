using Microsoft.EntityFrameworkCore;
using PostLikeQueryService.Shared.Dto;
using PostLikeQueryService.Shared.Model;

namespace PostLikeQueryService.Shared.PostgreSql.QuerRepositories
{
    internal class PostUserLikeQueryRepository(SqlContext context) : IPostUserLikeQueryRepository
    {
        public Task<List<PostUserLikeResponse>> GetByPostId(Guid postId, Guid? cursor, int pageSize, CancellationToken cancellationToken) =>
            context.PostUserLikes
                .AsNoTracking()
                .Where(x => !x.IsDeleted && x.PostId == postId && (cursor == null || x.SequenceId < cursor))
                .OrderByDescending(x => x.SequenceId)
                .Take(pageSize)
                .ToPostUserLikeResponse(context)
                .ToListAsync(cancellationToken);
    }
}
