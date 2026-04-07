using PostQueryService.Application.UseCases.UpsertPost;
using Shared.Events;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.UpsertPost_OnPostSoftDeleted
{
    internal class UpsertPost_OnPostSoftDeleted_Mapper
    {
        public UpsertPostRequest_Content Map(PostDeletedEvent_Content content) =>
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

        public UpsertPostRequest Map(PostSoftDeletedEvent @event) =>
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
