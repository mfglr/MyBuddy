namespace PostLikeQueryService.Domain.UserAggregate
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task CreateAsync(User user, CancellationToken cancellationToken = default);
        void Delete(User user);
    }
}
