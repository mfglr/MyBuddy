using AuthServer.Domain;
using Shared.Events.Account;

namespace AuthServer.Application.UseCases.UpdateEmail
{
    internal class UpdateEmailMapper
    {
        public AccountEmailUpdatedEvent Map(Account account) =>
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
                account.Media
            );
    }
}
