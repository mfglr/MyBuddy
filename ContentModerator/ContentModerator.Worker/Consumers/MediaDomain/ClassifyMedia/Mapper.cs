using ContentModerator.Application.UseCases.ClassifyMedia;
using Shared.Events.MediaService;

namespace ContentModerator.Worker.Consumers.MediaDomain.ClassifyMedia
{
    internal class Mapper
    {
        public ClassifyMediaRequest Map(MetadataExtractionValidatedEvent @event) =>
            new (
                @event.Id,
                @event.ContainerName,
                @event.BlobName,
                @event.Type,
                @event.Instruction
            );
    }
}
