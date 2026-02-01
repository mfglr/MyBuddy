namespace PostQueryService.Domain.UserDomain
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task CreateAsync(User user, CancellationToken cancellationToken);
        void Delete(User user);
    }
}
