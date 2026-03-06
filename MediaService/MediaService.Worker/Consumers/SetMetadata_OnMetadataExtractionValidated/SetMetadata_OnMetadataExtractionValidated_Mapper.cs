using MediaService.Application.UseCases.SetMetadata;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.SetMetadata_OnMetadataExtractionValidated
{
    internal class SetMetadata_OnMetadataExtractionValidated_Mapper
    {
        public SetMetadataRequest Map(MetadataExtractionValidatedEvent @event) =>
            new(
                new(@event.ContainerName, @event.BlobName),
                @event.Metadata
            );
    }
}
