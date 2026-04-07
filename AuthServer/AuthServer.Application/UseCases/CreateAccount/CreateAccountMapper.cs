using AuthServer.Domain;
using Shared.Events;
using Shared.Events.Account;

namespace AuthServer.Application.UseCases.CreateAccount
{
    internal class CreateAccountMapper
    {
        public MediaMessage Map(AccountMedia media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Context
            );

        public AccountCreatedEvent Map(Account account) =>
            new(
                Guid.Parse(account.Id),
                account.CreatedAt,
                account.UpdatedAt,
                account.DeletedAt,
                account.IsDeleted,
                account.Version,
                account.UserName!,
                account.Name?.Value,
                account.Gender.Value,
                account.Media.Select(Map)
            );
    }
}
