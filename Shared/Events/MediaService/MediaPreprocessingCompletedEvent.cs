using Media.Models;

namespace Shared.Events.MediaService
{
    public record MediaPreprocessingCompletedEvent(
        Guid Id,
        string ContainerName,
        string BlobName,
        MediaProcessingContext Context
    );
}
