using Shared.Events.MediaService;
using UserService.Application.UseCases.SetMedia;

namespace UserService.Worker.Consumers.SetUserMedia
{
    internal class SetUserMediaMapper
    {
        public SetMediaRequest Map(MediaPreprecessingCompletedEvent @event) =>
            new(
                @event.Id,
                @event.BlobName,
                @event.Metadata,
                @event.ModerationResult,
                @event.Thumbnails
            );
    }
}
