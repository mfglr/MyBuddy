using PostQueryService.Shared.Model;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.UpsertPostOnPostMediaSet
{
    internal class UpsertPost_OnPostMediaSet_Mapper
    {
        private Content Map(PostMediaSetEvent_Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );
        public Post Map(PostMediaSetEvent @event) =>
            new (
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
