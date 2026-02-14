using PostLikeQueryService.Application.UseCases.UpgradePostLike;
using Shared.Events.PostLikeService;

namespace PostLikeQueryService.Worker.Consumers.UpgradePostLike_OnPostDisliked
{
    internal class UpgradePostLike_OnPostDisliked_Mapper
    {
        public UpgradePostLikeRequest Map(PostDislikedEvent @event) =>
            new(
                @event.UserId,
                @event.PostId,
                @event.Version,
                @event.IsDeleted,
                @event.CreatedAt
            );
    }
}
