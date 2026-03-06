using MediaService.Application.UseCases.SetMetadata;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.SetMetadata_OnMetadataExtractionInvalidated
{
    internal class SetMetadata_OnMetadataExtractionInvalidated_Mapper
    {
        public SetMetadataRequest Map(MetadataExtractionInvalidatedEvent @event) =>
            new(
                new(@event.ContainerName,@event.BlobName),
                @event.Metadata
            );
    }
}
