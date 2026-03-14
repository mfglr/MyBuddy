using Shared.Events.SharedObjects;

namespace Shared.Events.PostService
{
    public record PostCreatedEvent_Content(string Value);
    public record PostCreatedEvent_Media(
        string ContainerName,
        string BlobName,
        MediaType Type,
        MediaInstruction Instruction
    );
    public record PostCreatedEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        DateTime? DeletedAt,
        bool IsDeleted,
        int Version,
        Guid UserId,
        PostCreatedEvent_Content? Content,
        IEnumerable<PostCreatedEvent_Media> Media
    );
}
