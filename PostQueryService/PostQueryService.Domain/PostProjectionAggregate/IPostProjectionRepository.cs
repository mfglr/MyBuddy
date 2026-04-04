namespace PostQueryService.Domain.PostProjectionAggregate
{
    public interface IPostProjectionRepository
    {
        Task<(PostProjection? postProjection, long? primaryTerm, long? sequenceNumber)> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task CreateAsync(PostProjection postProjection, CancellationToken cancellationToken);
        Task UpdateAsync(PostProjection postProjection, long? primaryTerm, long? sequenceNumber, CancellationToken cancellation);
    }
}
