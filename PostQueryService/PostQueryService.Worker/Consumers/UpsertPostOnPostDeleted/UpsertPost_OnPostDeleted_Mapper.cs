using PostQueryService.Shared.Model;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.UpsertPostOnPostDeleted
{
    internal class UpsertPost_OnPostDeleted_Mapper
    {
        private Content Map(PostDeletedEvent_Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );
        public Post Map(PostDeletedEvent @event) =>
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
