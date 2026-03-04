using Shared.Events.SharedObjects;

namespace Shared.Events.MediaService
{
    public record ThumbnailsGeneratedEvent(
        Guid Id,
        string ContainerName,
        string BlobName,
        IEnumerable<Thumbnail> Thumbnails
    );
}
