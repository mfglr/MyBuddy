namespace AuthServer.Domain
{
    public class AccountCreatorDomainService(IAccountRepository accountRepository)
    {
        public async Task<Account> Create(Email email, string password)
        {
            if (await accountRepository.ExistAsync(email))
                throw new EmailAlreadyTakenException();

            var account = new Account(email);
            await accountRepository.CreateAsync(account, password);
            return account;
        }
    }
}
