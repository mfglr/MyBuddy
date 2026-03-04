using MediaService.Application.UseCases.DeleteMedia;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.DeleteMedia
{
    internal class Mapper
    {
        public DeleteMediaRequest Map(MediaPreprecessingCompletedEvent @event) =>
            new(
                new(@event.ContainerName,@event.BlobName)
            );
    }
}
