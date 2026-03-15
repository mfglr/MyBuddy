using PostLikeQueryService.Shared.Model;
using Shared.Events.PostLikeService;

namespace PostLikeQueryService.Worker.Consumers.UpsertPostUserLike_OnPostLiked
{
    internal class UpsertPostUserLike_OnPostLiked_Mapper
    {
        public PostUserLike Map(PostLikedEvent @event) =>
            new(
                @event.SequenceId,
                @event.CreatedAt,
                @event.IsDeleted,
                @event.DeletedAt,
                @event.Version,
                @event.PostId,
                @event.UserId
            );
    }
}
