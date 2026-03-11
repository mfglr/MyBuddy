namespace PostQueryService.Shared.Model
{
    public interface IUserRepository
    {
        Task<int> UpsertAsync(User user, CancellationToken cancellationToken);
    }
}
