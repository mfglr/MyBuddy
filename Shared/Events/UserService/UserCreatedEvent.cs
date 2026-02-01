namespace Shared.Events.UserService
{
    public record UserCreatedEvent_Media(
        string ContainerName,
        string BlobName,
        MediaType Type,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails,
        bool IsDeleted,
        bool IsActive
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
        IEnumerable<UserCreatedEvent_Media> Media
    );
}
