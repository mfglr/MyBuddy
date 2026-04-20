namespace PostQueryService.Domain.PostProjectionAggregate
{
    public interface IPostProjectionRepository
    {
        Task<List<(PostProjection postProjection, long? primaryTerm, long? sequenceNumber)>> GetPostByUserAsync(
            string userId,
            int version,
            string? cursor,
            int pageSize,
            CancellationToken cancellationToken
        );
        Task<(PostProjection? postProjection, long? primaryTerm, long? sequenceNumber)> GetByIdAsync(string id, CancellationToken cancellationToken);
        Task CreateAsync(PostProjection postProjection, CancellationToken cancellationToken);
        Task UpdateAsync((PostProjection postProjection, long? primaryTerm, long? sequenceNumber) tuple, CancellationToken cancellation);
        Task UpdateManyAsync(IEnumerable<(PostProjection postProjection, long? primaryTerm, long? sequenceNumber)> tuples, CancellationToken cancellationToken);
        Task DeleteAsync(PostProjection postProjection, CancellationToken cancellationToken);
    }
}
