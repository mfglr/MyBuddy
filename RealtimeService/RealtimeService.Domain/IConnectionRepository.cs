namespace RealtimeService.Domain
{
    public interface IConnectionRepository
    {
        Task<Connection?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task CreateAsync(Connection connection, CancellationToken cancellationToken = default);
        Task UpdateAsync(Connection connection, CancellationToken cancellationToken = default);
        Task DeleteAsync(Connection connection, CancellationToken cancellationToken = default);
    }
}
