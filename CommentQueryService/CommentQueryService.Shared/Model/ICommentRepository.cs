namespace CommentQueryService.Shared.Model
{
    public interface ICommentRepository
    {
        Task<int> UpsertAsync(Comment comment, CancellationToken cancellationToken);
        Task<int> IncreaseChildCount(Guid id, CancellationToken cancellationToken);
        Task<int> DecreaseChildCount(Guid id, CancellationToken cancellationToken);
        Task<int> IncreaseLikeCount(Guid id, CancellationToken cancellationToken);
        Task<int> DecreaseLikeCount(Guid id, CancellationToken cancellationToken);
    }
}
