namespace PostLikeQueryService.Domain.PostLikeAggregate
{
    public interface IPostLikeRepository
    {
        Task<PostLike?> GetAsync(Guid postId, Guid userId, CancellationToken cancellationToken = default);
        Task<List<PostLike>> GetByPostIdAsync(Guid postId, CancellationToken cancellationToken = default);
        Task CreateAsync(PostLike like, CancellationToken cancellationToken = default);
        void Delete(PostLike like);
        void Delete(IEnumerable<PostLike> likes);
    }
}
