using Shared.Events.SharedObjects;

namespace Shared.Events.UserService
{
    public record UserMediaDeletedEvent_MediaDeleted(
        string ContainerName,
        string BlobName
    );
    public record UserMediaDeletedEvent_Media(
        string ContainerName,
        string BlobName,
        MediaType Type,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails
    );
    public record UserMediaDeletedEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        int Version,
        bool IsDeleted,
        string? Name,
        string UserName,
        string Gender,
        IEnumerable<UserMediaDeletedEvent_Media> Media,
        UserMediaDeletedEvent_MediaDeleted MediaDeleted
    );
}
