using Shared.Events.SharedObjects;

namespace Shared.Events.PostService
{
    public record PostMediaSetEvent_Content(
        string Value,
        ModerationResult? ModerationResult
    );
    public record PostMediaSetEvent_Media(
        string ContainerName,
        string BlobName,
        MediaType Type,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails,
        IEnumerable<Transcoding> Transcodings,
        MediaInstruction Instuction
    );
    public record PostMediaSetEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        Guid UserId,
        int Version,
        bool IsDeleted,
        PostMediaSetEvent_Content? Content,
        IEnumerable<PostMediaSetEvent_Media> Media,
        bool IsValidVersion
    );
}
