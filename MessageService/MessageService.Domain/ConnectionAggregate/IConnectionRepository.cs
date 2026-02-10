namespace MessageService.Domain.ConnectionAggregate
{
    public interface IConnectionRepository
    {
        Task<Connection?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task CreateAsync(Connection connection,CancellationToken cancellationToken);
        Task UpdateAsync(Connection connection,CancellationToken cancellationToken);
        Task DeleteAsync(Connection connection,CancellationToken cancellationToken);
    }
}
