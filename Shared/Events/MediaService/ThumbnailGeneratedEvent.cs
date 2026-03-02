using Shared.Events.SharedObjects;

namespace Shared.Events.MediaService
{
    public record ThumbnailGeneratedEvent(
        string ConatinerName,
        string BlobName,
        Thumbnail ThumbnailBlobName
    );
}
