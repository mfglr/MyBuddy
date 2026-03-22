namespace CommentLikeQueryService.Domain
{
    public interface ICommentLikeProjectionRepository
    {
        Task<List<CommentLikeProjection>> GetByCommentIdAsync(Guid commentId, Guid? cursor, int pageSize, CancellationToken cancellationToken);
        
        Task<CommentLikeProjection> GetByIdAsync(ProjectionId id, CancellationToken cancellationToken);
        Task<List<CommentLikeProjection>> GetByUserAsync(User user, CancellationToken cancellationToken);

        Task CreateAsync(CommentLikeProjection projection, CancellationToken cancellationToken);
        Task UpdateAsync(CommentLikeProjection projection, CancellationToken cancellationToken);
        Task UpdateAsync(List<CommentLikeProjection> projections, CancellationToken cancellationToken);
    }
}
