namespace PostQueryService.Domain.UserAggregate
{
    public interface IUserRepository
    {
        Task<(User? user, long? primaryTerm, long? sequenceNumber)> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task CreateAync(User user, CancellationToken cancellationToken);
        Task UpdateAsync(User user, long? primaryTerm, long? sequenceNumber, CancellationToken cancellationToken);
    }
}
