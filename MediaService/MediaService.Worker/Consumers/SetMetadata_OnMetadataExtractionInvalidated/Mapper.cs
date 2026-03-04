using MediaService.Application.UseCases.SetMetadata;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.SetMetadata_OnMetadataExtractionInvalidated
{
    internal class Mapper
    {
        public SetMetadataRequest Map(MetadataExtractionInvalidatedEvent @event) =>
            new(
                new(@event.Id,@event.ContainerName),
                @event.BlobName,
                @event.Metadata
            );
    }
}
