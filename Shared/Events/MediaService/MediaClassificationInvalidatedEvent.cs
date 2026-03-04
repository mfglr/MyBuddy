using Shared.Events.SharedObjects;

namespace Shared.Events.MediaService
{
    public record MediaClassificationInvalidatedEvent(
        Guid Id,
        string ContainerName,
        string BlobName,
        ModerationResult ModerationResult
    );
}
