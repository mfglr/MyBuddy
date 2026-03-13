namespace Shared.Events.Account
{
    public record AccountUserNameUpdatedEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        DateTime? DeletedAt,
        bool IsDeleted,
        int Version,
        string UserName
    );
}
