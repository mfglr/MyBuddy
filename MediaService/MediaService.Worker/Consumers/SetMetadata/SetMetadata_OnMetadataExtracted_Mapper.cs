using MediaService.Application.UseCases.SetMetadata;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.SetMetadata
{
    internal class SetMetadata_OnMetadataExtracted_Mapper
    {
        public SetMetadataRequest Map(MediaMetadataExtractedEvent @event) =>
            new(
                @event.ContainerName,
                @event.BlobName,
                @event.Metadata
            );
    }
}
