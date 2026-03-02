using MediaService.Application.UseCases.SetModerationResult;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.SetModerationResult_OnClassificationInvalidated
{
    internal class Mapper
    {
        public SetModerationResultRequest Map(MediaClassificationInvalidatedEvent @event) =>
            new(
                @event.ContainerName,
                @event.BlobName,
                @event.ModerationResult
            );
    }
}
