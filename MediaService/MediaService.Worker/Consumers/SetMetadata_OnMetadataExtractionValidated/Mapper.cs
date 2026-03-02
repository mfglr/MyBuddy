using MediaService.Application.UseCases.SetMetadata;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.SetMetadata_OnMetadataExtractionValidated
{
    internal class Mapper
    {
        public SetMetadataRequest Map(MetadataExtractionValidatedEvent @event) =>
            new(
                @event.ContainerName,
                @event.BlobName,
                @event.Metadata
            );
    }
}
