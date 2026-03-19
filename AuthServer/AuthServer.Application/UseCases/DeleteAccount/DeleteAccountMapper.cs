using AuthServer.Domain;
using Shared.Events.Account;

namespace AuthServer.Application.UseCases.DeleteAccount
{
    internal class DeleteAccountMapper
    {
        public AccountDeletedEvent Map(Account account) =>
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
