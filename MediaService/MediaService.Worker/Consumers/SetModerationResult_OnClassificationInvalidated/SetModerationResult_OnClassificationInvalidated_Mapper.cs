using MediaService.Application.UseCases.SetModerationResult;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.SetModerationResult_OnClassificationInvalidated
{
    internal class SetModerationResult_OnClassificationInvalidated_Mapper
    {
        public SetModerationResultRequest Map(MediaClassificationInvalidatedEvent @event) =>
            new(
                new(@event.ContainerName, @event.BlobName),
                @event.ModerationResult
            );
    }
}
