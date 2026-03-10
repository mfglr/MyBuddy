using Shared.Events.MediaService;
using Shared.Events.SharedObjects;

namespace MetadataExtractor.Application.UseCases.ExtractMetadata
{
    public class ExtractMetadataMapper
    {
        public MediaMetadataExtractedEvent Map(ExtractMetadataRequest request, Metadata metadata) =>
            new(
                request.ContainerName,
                request.BlobName,
                metadata
            );
    }
}
