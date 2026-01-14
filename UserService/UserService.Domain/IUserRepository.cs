namespace UserService.Domain
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user, CancellationToken cancellationToken);
    }
}
