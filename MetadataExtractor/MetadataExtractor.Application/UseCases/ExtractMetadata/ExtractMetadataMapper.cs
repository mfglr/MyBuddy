using Shared.Events.MediaService;
using Shared.Events.SharedObjects;

namespace MetadataExtractor.Application.UseCases.ExtractMetadata
{
    public class ExtractMetadataMapper
    {
        public MetadataExtractionValidatedEvent MapValidatedEvent(ExtractMetadataRequest request, Metadata metadata) =>
            new(
                request.Id,
                request.ContainerName,
                request.BlobName,
                request.Type,
                metadata,
                request.Instruction
            );

        public MetadataExtractionInvalidatedEvent MapInvalidatedEvent(ExtractMetadataRequest request, Metadata metadata) =>
            new(
                request.Id,
                request.ContainerName,
                request.BlobName,
                metadata
            );
    }
}
