namespace PostQueryService.Domain
{
    public interface IPostProjectionRepository
    {
        Task<PostProjection?> GetByIdAsync(string id, CancellationToken cancellationToken);
        Task<IReadOnlyCollection<PostProjection>> GetByUserAsync(User user, CancellationToken cancellationToken);
        Task CreateAsync(PostProjection postProjection, CancellationToken cancellationToken);
        Task UpdateAsync(PostProjection postProjection, CancellationToken cancellationToken);
        Task UpdateAsync(List<PostProjection> postProjections, CancellationToken cancellationToken);
        Task DeleteAsync(List<PostProjection> postProjections, CancellationToken cancellationToken);
    }
}
