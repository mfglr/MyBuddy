using Shared.Events.SharedObjects;

namespace Shared.Events.UserService
{
    public record UserMediaCreatedEvent_MediaCreated(
        Guid Id,
        string ContainerName,
        string BlobName,
        MediaType Type,
        MediaInstruction Instruction
    );
    public record UserMediaCreatedEvent_Media(
        string ContainerName,
        string BlobName,
        MediaType Type,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails
    );
    public record UserMediaCreatedEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        int Version,
        bool IsDeleted,
        string? Name,
        string UserName,
        string Gender,
        IEnumerable<UserMediaCreatedEvent_Media> Media,
        UserMediaCreatedEvent_MediaCreated MediaCreated
    );
}
