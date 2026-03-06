using PostQueryService.Shared.Model;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.UpsertPostOnPostContentModerationResultSet
{
    internal class UpsertPost_OnPostContentModerationResultSet_Mapper
    {
        private Content Map(PostContentModerationResultSetEvent_Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );
        private Media Map(PostContentModerationResultSetEvent_Media media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Type,
                media.Metadata,
                media.ModerationResult,
                media.Thumbnails,
                media.TranscodedBlobName
            );
        public Post Map(PostContentModerationResultSetEvent @event) =>
            new(
                @event.Id,
                @event.CreatedAt,
                @event.UpdatedAt,
                @event.Version,
                @event.UserId,
                @event.Content != null ? Map(@event.Content) : null,
                @event.Media.Select(Map)
            );
    }
}
