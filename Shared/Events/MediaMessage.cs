using Media.Models;

namespace Shared.Events
{
    public record MediaMessage(
        string ContainerName,
        string BlobName,
        MediaProcessingContext Context
    );
}
