namespace CommentQueryService.Domain
{
    public interface ICommentProjectionRepository
    {
        Task<List<CommentProjection>> GetByPostIdAsync(Guid postId, Guid? cursor, int pageSize, CancellationToken cancellationToken);
        Task<List<CommentProjection>> GetByParentIdAsync(Guid parentId, Guid? cursor, int pageSize, CancellationToken cancellationToken);

        Task<CommentProjection?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<CommentProjection>> GetByUserAsync(User user, CancellationToken cancellationToken);
        Task CreateAsync(CommentProjection comment, CancellationToken cancellationToken);
        Task UpdateAsync(CommentProjection comment, CancellationToken cancellationToken);
        Task UpdateAsync(IEnumerable<CommentProjection> comments, CancellationToken cancellationToken);

        Task IncreaseChildCount(Guid id, CancellationToken cancellationToken);
        Task DecreaseChildCount(Guid id, CancellationToken cancellationToken);
        Task IncreaseLikeCount(Guid id, CancellationToken cancellationToken);
        Task DecreaseLikeCount(Guid id, CancellationToken cancellationToken);
    }
}
