using PostService.Application.UseCases.SetPostMedia;
using Shared.Events.MediaService;

namespace PostService.Workers.Consumers.SetPostMedia
{
    internal class SetPostMedia_OnMediaPreprocessingCompleted_Mapper
    {
        public SetPostMediaRequest Map(MediaPreprocessingCompletedEvent @event) =>
            new(
                @event.Id,
                @event.BlobName,
                @event.Context
            );
    }
}
