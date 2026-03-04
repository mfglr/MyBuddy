using PostService.Application.UseCases.SetPostMedia;
using Shared.Events.MediaService;

namespace PostService.Workers.Consumers.SetPostMedia
{
    internal class Mapper
    {
        public SetPostMediaRequest Map(MediaPreprecessingCompletedEvent @event) =>
            new(
                @event.Id,
                @event.BlobName,
                @event.Metadata,
                @event.ModerationResult,
                @event.Thumbnails,
                @event.TranscodedBlobName
            );
    }
}
