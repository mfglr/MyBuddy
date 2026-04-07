namespace PostService.Domain
{
    public interface IPostRepository
    {
        Task<List<Post>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);

        Task<Post?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task CreateAsync(Post post, CancellationToken cancellationToken);
        Task UpdateAsync(Post post, CancellationToken cancellationToken);
        Task UpdateAsync(IEnumerable<Post> posts, CancellationToken cancellationToken);
        Task DeleteAsync(Post post, CancellationToken cancellationToken);
    }
}
