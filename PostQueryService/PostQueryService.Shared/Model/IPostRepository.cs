namespace PostQueryService.Shared.Model
{
    public interface IPostRepository
    {
        Task UpsertAsync(Post post, CancellationToken cancellationToken);
        Task<int> IncreaseLikeCount(Guid id, CancellationToken cancellationToken);
        Task<int> DecreaseLikeCount(Guid id, CancellationToken cancellationToken);
        Task<int> IncreaseCommentCount(Guid id, CancellationToken cancellationToken);
        Task<int> DecreaseCommentCount(Guid id, CancellationToken cancellationToken);
    }
}
