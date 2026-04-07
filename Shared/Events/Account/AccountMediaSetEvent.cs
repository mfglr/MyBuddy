namespace Shared.Events.Account
{
    public record AccountMediaSetEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        DateTime? DeletedAt,
        bool IsDeleted,
        int Version,
        string UserName,
        string? Name,
        string Gender,
        IEnumerable<MediaMessage> Media
    );
}
