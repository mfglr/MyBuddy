using CommentQueryService.Shared.Dto;

namespace CommentQueryService.Shared.Model
{
    public interface ICommentQueryRepository
    {
        Task<List<CommentResponse>> GetByPostIdAsync(Guid postId, Guid? cursor, int pageSize, CancellationToken cancellationToken);
        Task<List<CommentResponse>> GetByParentIdAsync(Guid parentId, Guid? cursor, int pageSize, CancellationToken cancellationToken);
    }
}
