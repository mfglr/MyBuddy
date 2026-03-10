using MediaService.Application.UseCases.SetModerationResult;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.SetModerationResult
{
    internal class SetModerationResult_OnMediaClassified_Mapper
    {
        public SetModerationResultRequest Map(MediaClassifiedEvent @event) =>
            new(
                @event.ContainerName,
                @event.BlobName,
                @event.ModerationResult
            );
    }
}
