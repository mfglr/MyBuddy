using Shared.Objects;

namespace Shared.Events.MediaService
{
    public record MediaThumbnailGeneratedEvent(Guid Id, Thumbnail Thumbnail);
}
