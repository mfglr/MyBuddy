using QueryService.Domain.PostDomain;

namespace PostService.Domain
{
    public interface IPostRepository
    {
        Task CreateAsync(Post post, CancellationToken cancellationToken);
        void Delete(Post post, CancellationToken cancellationToken);
        Task<Post?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
