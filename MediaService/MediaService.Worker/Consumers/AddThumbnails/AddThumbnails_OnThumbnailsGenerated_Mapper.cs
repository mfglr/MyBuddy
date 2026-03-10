using MediaService.Application.UseCases.AddThumbnail;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.AddThumbnails
{
    internal class AddThumbnails_OnThumbnailsGenerated_Mapper
    {
        public AddThumbnailRequest Map(ThumbnailGeneratedEvent @event) =>
            new(
                @event.ContainerName,
                @event.BlobName,
                @event.Thumbnail
            );
    }
}
