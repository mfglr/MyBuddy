using Media.Models;

namespace Shared.Events.MediaService
{
    public record ThumbnailGeneratedEvent(
        string ContainerName,
        string BlobName,
        Thumbnail Thumbnail
    );
}
