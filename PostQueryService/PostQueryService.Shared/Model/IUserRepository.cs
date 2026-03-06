namespace PostQueryService.Shared.Model
{
    public interface IUserRepository
    {
        Task UpsertAsync(User user, CancellationToken cancellationToken);
    }
}
