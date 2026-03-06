using MediaService.Application.UseCases.DeleteMedia;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.DeleteMedia
{
    internal class DeleteMedia_OnMediaPreprocessingCompleted_Mapper
    {
        public DeleteMediaRequest Map(MediaPreprocessingCompletedEvent @event) =>
            new(
                new(@event.ContainerName,@event.BlobName)
            );
    }
}
