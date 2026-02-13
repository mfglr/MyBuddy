using PostLikeQueryService.Application.UseCases.UpgradePostLike;
using Shared.Events.PostLikeService;

namespace PostLikeQueryService.Worker.Consumers.UpgradePostLike_OnPostLiked
{
    internal class Mapper
    {
        public UpgradePostLikeRequest Map(PostLikedEvent @event) =>
            new(
                @event.UserId,
                @event.PostId,
                @event.Version,
                @event.IsDeleted,
                @event.CreatedAt
            );
    }
}
