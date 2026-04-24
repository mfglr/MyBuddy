namespace CommentLikeQueryService.Domain.CommentLikeAggregate
{
    public interface ICommentLikeRepository
    {
        Task<List<CommentLike>> GetByCommentIdAsync(Guid commentId, Guid? cursor, int pageSize, CancellationToken cancellationToken);
        
        Task<CommentLike?> GetByIdAsync(CommentLikeId id, CancellationToken cancellationToken);
        Task CreateAsync(CommentLike like, CancellationToken cancellationToken);
        Task DeleteAsync(CommentLike like, CancellationToken cancellationToken);
        //Task UpdateAsync(List<CommentLike> likes, CancellationToken cancellationToken);
    }
}
