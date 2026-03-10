using Shared.Events.SharedObjects;

namespace Shared.Events.MediaService
{
    public record MediaClassifiedEvent(
        string ContainerName,
        string BlobName,
        ModerationResult ModerationResult
    );
}
