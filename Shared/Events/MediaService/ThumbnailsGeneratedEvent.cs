using Shared.Events.SharedObjects;

namespace Shared.Events.MediaService
{
    public record ThumbnailsGeneratedEvent(
        string ContainerName,
        string BlobName,
        IEnumerable<Thumbnail> Thumbnails
    );
}
