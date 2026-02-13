namespace PostLikeService.Domain
{
    public interface IPostLikeRepository
    {
        Task<PostLike?> GetAsync(PostLikeId id, CancellationToken cancellationToken);
        Task<List<PostLike>> GetByPostIdAsync(Guid postId, CancellationToken cancellationToken);
        Task<bool> ExistAsync(PostLikeId id, CancellationToken cancellationToken);
        Task CreateAsync(PostLike postLike, CancellationToken cancellationToken = default);
        Task UpdateAsync(PostLike postLike, CancellationToken cancellationToken = default);
        Task DeleteAsync(PostLike postLike, CancellationToken cancellationToken = default);
        Task UpdateAsync(IEnumerable<PostLike> postLikes, CancellationToken cancellationToken = default);
    }
}
