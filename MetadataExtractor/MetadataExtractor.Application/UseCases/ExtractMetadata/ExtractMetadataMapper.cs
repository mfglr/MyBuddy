using Media.Models;
using Shared.Events.MediaService;

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
