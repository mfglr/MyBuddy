namespace CommentLikeService.Domain
{
    public interface ICommentLikeRepository
    {
        Task<CommentLike?> GetByIdAsync(CommentLikeId id, CancellationToken cancellationToken);
        Task<List<CommentLike>> GetCommentLikesByCommentIdAsync(Guid commentId, CancellationToken cancellationToken);
        Task<List<CommentLike>> GetCommentLikesExceptDeletedAsync(Guid commentId, CancellationToken cancellationToken);
        Task<bool> ExistAsync(CommentLikeId id, CancellationToken cancellationToken);

        Task CreateAsync(CommentLike commentLike, CancellationToken cancellationToken);
        Task UpdateAsync(CommentLike commentLike, CancellationToken cancellationToken);
        Task UpdateAsync(IEnumerable<CommentLike> commentLikes, CancellationToken cancellationToken);
        Task DeleteAsync(CommentLike commentLike, CancellationToken cancellationToken);
    }
}
