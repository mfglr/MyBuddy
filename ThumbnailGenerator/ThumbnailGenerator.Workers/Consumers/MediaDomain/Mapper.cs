using Shared.Events.MediaService;
using ThumbnailGenerator.Application.UseCases.GenerateThumbnails;

namespace ThumbnailGenerator.Workers.Consumers.MediaDomain
{
    internal class Mapper
    {
        public GenerateThumbnailsRequest Map(MediaClassificationValidatedEvent @event) =>
            new(
                @event.Id,
                @event.ContainerName,
                @event.BlobName,
                @event.Instruction.ThumbnailInstructions
            );
    }
}
