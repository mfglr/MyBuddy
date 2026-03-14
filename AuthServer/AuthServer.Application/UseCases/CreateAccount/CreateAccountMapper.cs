using AuthServer.Domain;
using Shared.Events.Account;

namespace AuthServer.Application.UseCases.CreateAccount
{
    internal class CreateAccountMapper
    {
        public AccountCreatedEvent Map(Account account) =>
            new(Guid.Parse(account.Id));
    }
}
