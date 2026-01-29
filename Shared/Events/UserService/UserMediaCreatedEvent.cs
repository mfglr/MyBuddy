namespace Shared.Events.UserService
{
    public record UserMediaCreatedEvent(
        Guid Id,
        string ContainerName,
        string BlobName
    );
}
