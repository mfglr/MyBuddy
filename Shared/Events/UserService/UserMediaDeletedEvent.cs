namespace Shared.Events.UserService
{
    public record UserMediaDeletedEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        int Version,
        bool IsDeleted,
        string? Name,
        string UserName,
        string Gender,
        IEnumerable<Media.Models.Media> Media,
        Media.Models.Media MediaDeleted
    );
}
