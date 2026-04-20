using PostQueryService.Domain.PostProjectionAggregate;
using Shared;

namespace PostQueryService.Application.UseCases
{
    public interface IPostQueryRepository
    {
        Task<PostProjection?> GetByIdQueryAsync(string id, CancellationToken cancellationToken);
        Task<IEnumerable<PostProjection>> GetByUserIdAsync(
            string userId,
            int pageSize,
            PaginationKey<string> cursor,
            CancellationToken cancellationToken
        );
        Task<IEnumerable<(PostProjection post, double? score)>> SearchAsync(
            string key,
            double? score,
            string? id,
            int pageSize,
            CancellationToken cancellationToken
        );
    }
}
