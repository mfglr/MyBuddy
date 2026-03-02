namespace PostService.Domain
{
    public interface IPostRepository
    {
        Task<Post?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task CreateAsync(Post post, CancellationToken cancellationToken);
        void Delete(Post post, CancellationToken cancellationToken);
    }
}
