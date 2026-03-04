using Shared.Events.SharedObjects;

namespace Shared.Events.MediaService
{
    public record MediaPreprecessingCompletedEvent_Media(
        string BlobName,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        string? TranscodedBlobName,
        IEnumerable<Thumbnail> Thumbnails,
        MediaInstruction Instruction
    );
    public record MediaPreprecessingCompletedEvent(
        Guid Id,
        string ContainerName,
        IEnumerable<MediaPreprecessingCompletedEvent_Media> Media
    );
}
