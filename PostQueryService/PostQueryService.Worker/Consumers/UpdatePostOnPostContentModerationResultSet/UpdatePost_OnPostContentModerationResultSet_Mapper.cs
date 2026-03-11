using PostQueryService.Shared.Model;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.UpdatePostOnPostContentModerationResultSet
{
    internal class UpdatePost_OnPostContentModerationResultSet_Mapper
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
                media.Transcodings
            );
        public Post Map(PostContentModerationResultSetEvent @event) =>
            new(
                @event.Id,
                @event.CreatedAt,
                @event.UpdatedAt,
                @event.DeletedAt,
                @event.IsDeleted,
                @event.Version,
                @event.IsValidVersion,
                @event.UserId,
                @event.Content != null ? Map(@event.Content) : null,
                @event.Media.Select(Map)
            );
    }
}
