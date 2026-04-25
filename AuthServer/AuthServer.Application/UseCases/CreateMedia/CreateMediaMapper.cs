using AuthServer.Domain;
using Shared.Events;
using Shared.Events.Account;

namespace AuthServer.Application.UseCases.CreateMedia
{
    internal class CreateMediaMapper
    {
        public MediaMessage Map(AccountMedia media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Context
            );

        public AccountMediaCreatedEvent Map(Account account, AccountMedia mediaCreated) =>
            new(
                Guid.Parse(account.Id),
                account.CreatedAt,
                account.UpdatedAt,
                account.Version,
                account.UserName!,
                account.Name?.Value,
                account.Gender.Value,
                account.Media.Select(Map),
                Map(mediaCreated)
            );
    }
}
