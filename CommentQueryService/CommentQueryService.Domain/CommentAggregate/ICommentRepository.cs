using Shared;

namespace CommentQueryService.Domain.CommentAggregate
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetByPostIdAsync(Guid postId, int pageSize, PaginationKey<Guid?> Cursor, CancellationToken cancellationToken);
        Task<List<Comment>> GetByParentIdAsync(Guid parentId, int pageSize, PaginationKey<Guid?> Cursor, CancellationToken cancellationToken);

        Task<Comment?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Comment>> GetByUserIdAsync(Guid userId, int version, CancellationToken cancellationToken);
        Task CreateAsync(Comment comment, CancellationToken cancellationToken);
        Task UpdateAsync(Comment comment, CancellationToken cancellationToken);
        Task UpdateAsync(IEnumerable<Comment> comments, CancellationToken cancellationToken);
        Task DeleteAsync(Comment comment,CancellationToken cancellationToken);

        Task IncreaseChildCount(Guid id, CancellationToken cancellationToken);
        Task DecreaseChildCount(Guid id, CancellationToken cancellationToken);
        Task IncreaseLikeCount(Guid id, CancellationToken cancellationToken);
        Task DecreaseLikeCount(Guid id, CancellationToken cancellationToken);
    }
}
