using Microsoft.AspNetCore.Identity;

namespace AuthServer.Domain
{
    public class EmailUpdaterDomainService(IAccountRepository accountRepository)
    {
        public async Task UpdateAsync(Account account, Email email)
        {
            if (await accountRepository.ExistAsync(email))
                throw new EmailAlreadyTakenException();

            account.UpdateEmail(email);
        }
    }
}
