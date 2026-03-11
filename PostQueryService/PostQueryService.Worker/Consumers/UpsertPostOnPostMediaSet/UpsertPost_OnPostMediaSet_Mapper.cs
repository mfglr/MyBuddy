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
        private Media Map(PostMediaSetEvent_Media media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Type,
                media.Metadata,
                media.ModerationResult,
                media.Thumbnails,
                media.Transcodings
            );
        public Post Map(PostMediaSetEvent @event) =>
            new (
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
