namespace UserQueryService.Shared.Model
{
    public interface IUserRepository
    {
        Task UpsertAsync(User user, CancellationToken cancellationToken);
        Task<User?> GetByIdAsync(Guid id,CancellationToken cancellationToken);
        Task<List<User>> SearchAsync(string key, Guid? cursor, int pageSize, CancellationToken cancellationToken);

        Task IncreasePostCount(Guid id, CancellationToken cancellationToken);
        Task DecreasePostCount(Guid id, CancellationToken cancellationToken);
    }
}
