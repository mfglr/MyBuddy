using PostLikeQueryService.Shared.Model;
using Shared.Events.PostLikeService;

namespace PostLikeQueryService.Worker.Consumers.UpsertPostUserLike_OnPostDisliked
{
    internal class UpsertPostUserLike_OnPostDisliked_Mapper
    {
        public PostUserLike Map(PostDislikedEvent @event) =>
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
