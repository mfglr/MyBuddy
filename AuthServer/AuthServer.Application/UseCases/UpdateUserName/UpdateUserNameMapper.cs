using AuthServer.Domain;
using Shared.Events.Account;

namespace AuthServer.Application.UseCases.UpdateUserName
{
    internal class UpdateUserNameMapper
    {
        public AccountUserNameUpdatedEvent Map(Account account) =>
            new(
                Guid.Parse(account.Id),
                account.CreatedAt,
                account.UpdatedAt,
                account.DeletedAt,
                account.IsDeleted,
                account.Version,
                account.UserName!,
                account.Name?.Value,
                account.Gender.Value
            );
    }
}
