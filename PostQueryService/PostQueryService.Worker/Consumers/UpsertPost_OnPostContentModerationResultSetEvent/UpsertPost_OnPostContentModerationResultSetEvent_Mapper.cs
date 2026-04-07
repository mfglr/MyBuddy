using PostQueryService.Application.UseCases.UpsertPost;
using Shared.Events;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.UpsertPost_OnPostContentModerationResultSetEvent
{
    internal class UpsertPost_OnPostContentModerationResultSetEvent_Mapper
    {
        public UpsertPostRequest_Content Map(PostContentModerationResultSetEvent_Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );

        public UpsertPostRequest_Media Map(MediaMessage media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Context
            );

        public UpsertPostRequest Map(PostContentModerationResultSetEvent @event) =>
            new(
                @event.Id,
                @event.CreatedAt,
                @event.UpdatedAt,
                @event.SoftDeletedAt,
                @event.IsHardDeleted,
                @event.Version,
                @event.UserId,
                @event.Content != null ? Map(@event.Content) : null,
                @event.Media.Select(Map)
            );
    }
}
