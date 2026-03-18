using PostQueryService.Shared.Model;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.UpsertPostOnPostRestored
{
    internal class UpsertPost_OnPostRestored_Mapper
    {
        private Content Map(PostRestoredEvent_Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );
        public Post Map(PostRestoredEvent @event) =>
            new(
                @event.Id,
                @event.CreatedAt,
                @event.UpdatedAt,
                @event.DeletedAt,
                @event.IsDeleted,
                @event.Version,
                @event.UserId,
                @event.Content != null ? Map(@event.Content) : null,
                @event.Media
            );
    }
}
