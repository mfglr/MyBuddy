using Shared.Events.SharedObjects;

namespace Shared.Events.MediaService
{
    public record MediaPreprecessingCompletedEvent(
        Guid OwnerId,
        string ContainerName,
        string BlobName,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        string? TranscodedBlobName,
        IEnumerable<Thumbnail> Thumbnails,
        MediaInstruction Instruction
    );
}
