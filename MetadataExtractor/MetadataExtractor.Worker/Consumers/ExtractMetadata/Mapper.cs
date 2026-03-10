using MetadataExtractor.Application.UseCases.ExtractMetadata;
using Shared.Events.MediaService;

namespace MetadataExtractor.Worker.Consumers.ExtractMetadata
{
    internal class Mapper
    {
        public ExtractMetadataRequest Map(ExtractMediaMetadataMessage message) =>
            new(
                message.ContainerName,
                message.BlobName
            );
    }
}
