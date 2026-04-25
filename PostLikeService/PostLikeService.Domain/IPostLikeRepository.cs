namespace PostLikeService.Domain
{
    public interface IPostLikeRepository
    {
        Task<PostLike?> GetByIdAsync(PostLikeId id, CancellationToken cancellationToken = default);
        Task<List<PostLike>> GetByPostIdAsync(Guid postId, CancellationToken cancellationToken = default);
        Task<bool> ExistAsync(PostLikeId id, CancellationToken cancellationToken = default);
        Task CreateAsync(PostLike postLike, CancellationToken cancellationToken = default);
        Task DeleteAsync(PostLike postLike, CancellationToken cancellationToken = default);
        Task DeleteAsync(IEnumerable<PostLike> postLikes, CancellationToken cancellationToken = default);
    }
}
