using MediaService.Application.UseCases.SetModerationResult;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.SetModerationResult_OnClassificationValidated
{
    internal class Mapper
    {
        public SetModerationResultRequest Map(MediaClassificationValidatedEvent @event) =>
            new(
                new(@event.ContainerName, @event.BlobName),
                @event.ModerationResult
            );
    }
}
