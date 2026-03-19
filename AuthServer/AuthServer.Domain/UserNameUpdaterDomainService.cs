namespace AuthServer.Domain
{
    public class UserNameUpdaterDomainService(IAccountRepository accountRepository)
    {
        public async Task UpdateAsync(Account account, UserName userName)
        {
            if (await accountRepository.ExistAsync(userName))
                throw new UserNameAlreadyTakenException();

            account.UpdateUserName(userName);
        }
    }
}
