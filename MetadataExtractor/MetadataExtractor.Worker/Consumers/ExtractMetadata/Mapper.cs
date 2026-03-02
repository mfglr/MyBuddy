using MetadataExtractor.Application.UseCases.ExtractMetadata;
using Shared.Events.MediaService;

namespace MetadataExtractor.Worker.Consumers.ExtractMetadata
{
    internal class Mapper
    {
        public ExtractMetadataRequest Map(MediaCreatedEvent @event) =>
            new(
                @event.ContainerName,
                @event.BlobName,
                @event.Type,
                @event.Instruction
            );
    }
}
