using Shared.Events.MediaService;
using UserService.Application.UseCases.SetMedia;

namespace UserService.Worker.Consumers.SetUserMedia
{
    internal class SetUserMedia_OnMediaPreprocessingCompleted_Mapper
    {
        public SetMediaRequest Map(MediaPreprocessingCompletedEvent @event) =>
            new(
                @event.Id,
                @event.BlobName,
                @event.Metadata,
                @event.ModerationResult,
                @event.Thumbnails
            );
    }
}
