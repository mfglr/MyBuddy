using Shared.Events.SharedObjects;

namespace Shared.Events.MediaService
{
    public record MediaClassificationInvalidatedEvent(
        string ContainerName,
        string BlobName,
        ModerationResult ModerationResult
    );
}
