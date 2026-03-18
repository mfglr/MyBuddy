namespace Shared.Events.UserService
{
    public record UserNameUpdatedEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        int Version,
        bool IsDeleted,
        string? Name,
        string UserName,
        string Gender,
        IEnumerable<Media.Models.Media> Media
    );
}
