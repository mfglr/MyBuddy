using MediaService.Application.UseCases.SetThumbnails;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.SetThumbnails
{
    internal class SetThumbnails_OnThumbnailsGenerated_Mapper
    {
        public SetThumbnailsRequest Map(ThumbnailsGeneratedEvent @event) =>
            new(
                new(@event.ContainerName, @event.BlobName),
                @event.Thumbnails
            );
    }
}
