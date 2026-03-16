using CommentQueryService.Shared.Dto;
using CommentQueryService.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace CommentQueryService.Shared.PostgreSql.QuerRepositories
{
    internal class CommentQueryRepository(SqlContext context) : ICommentQueryRepository
    {
        public Task<List<CommentResponse>> GetByPostIdAsync(Guid postId, Guid? cursor, int pageSize, CancellationToken cancellationToken) =>
            context.Comments
                .AsNoTracking()
                .Where(x => x.PostId == postId && (cursor == null || x.Id < cursor))
                .OrderByDescending(x => x.Id)
                .Take(pageSize)
                .ToCommentResponse(context)
                .ToListAsync(cancellationToken);

        public Task<List<CommentResponse>> GetByParentIdAsync(Guid parentId, Guid? cursor, int pageSize, CancellationToken cancellationToken) =>
            context.Comments
                .AsNoTracking()
                .Where(x => x.ParentId == parentId && (cursor == null || x.Id < cursor))
                .OrderByDescending(x => x.Id)
                .Take(pageSize)
                .ToCommentResponse(context)
                .ToListAsync(cancellationToken);
    }
}
