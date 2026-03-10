using Shared.Events.SharedObjects;

namespace Shared.Events.MediaService
{
    public record MediaPreprocessingCompletedEvent(
        Guid Id,
        string ContainerName,
        string BlobName,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Transcoding> Transcodings,
        IEnumerable<Thumbnail> Thumbnails,
        MediaInstruction Instruction
    );
}
