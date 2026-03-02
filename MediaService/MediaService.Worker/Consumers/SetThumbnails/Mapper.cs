using MediaService.Application.UseCases.SetThumbnails;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.SetThumbnails
{
    internal class Mapper
    {
        public SetThumbnailsRequest Map(ThumbnailsGeneratedEvent @event) =>
            new(
                @event.ContainerName,
                @event.BlobName,
                @event.Thumbnails
            );
    }
}
