using Shared.Events.SharedObjects;

namespace Shared.Events.UserService
{
    public record UserCreatedEvent_Media(
        string ContainerName,
        string BlobName,
        MediaType Type,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails
    );
    public record UserCreatedEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        int Version,
        bool IsDeleted,
        string? Name,
        string UserName,
        string Gender,
        IEnumerable<UserCreatedEvent_Media> Media,
        bool IsValidVersion
    );
}
