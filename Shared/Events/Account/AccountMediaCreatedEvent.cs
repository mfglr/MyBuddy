namespace Shared.Events.Account
{
    public record AccountMediaCreatedEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        int Version,
        string UserName,
        string? Name,
        string Gender,
        IEnumerable<MediaMessage> Media,
        MediaMessage MediaCreated
    );
}
