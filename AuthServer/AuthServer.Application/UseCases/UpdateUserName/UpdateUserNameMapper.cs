using AuthServer.Domain;
using Shared.Events;
using Shared.Events.Account;

namespace AuthServer.Application.UseCases.UpdateUserName
{
    internal class UpdateUserNameMapper
    {
        public MediaMessage Map(AccountMedia media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Context
            );

        public AccountUserNameUpdatedEvent Map(Account account) =>
            new(
                Guid.Parse(account.Id),
                account.CreatedAt,
                account.UpdatedAt,
                account.Version,
                account.UserName!,
                account.Name?.Value,
                account.Gender.Value,
                account.Media.Select(Map)
            );
    }
}
