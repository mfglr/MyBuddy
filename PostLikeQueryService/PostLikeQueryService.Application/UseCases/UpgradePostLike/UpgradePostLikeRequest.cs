using MediatR;

namespace PostLikeQueryService.Application.UseCases.UpgradePostLike
{
    public record UpgradePostLikeRequest(Guid UserId, Guid PostId, int Version, bool IsDeleted, DateTime CreatedAt) : IRequest;
}
