namespace UserQueryService.Domain
{
    public interface IVersion;

    public record UserVersion(User User, IVersion Version);

    public interface IUserRepository
    {
        Task CreateAsync(User user, CancellationToken cancellationToken);
        Task<UserVersion?> GetByIdAsync(string id, CancellationToken cancellationToken);
        Task DeleteAsync(User user, CancellationToken cancelToken);
        Task UpdateAsync(User user, IVersion? version, CancellationToken cancelToken);
    }
}
