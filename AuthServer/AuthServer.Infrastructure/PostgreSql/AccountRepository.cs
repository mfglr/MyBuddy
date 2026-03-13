using AuthServer.Domain;
using Microsoft.AspNetCore.Identity;

namespace AuthServer.Infrastructure.PostgreSql
{
    internal class AccountRepository(UserManager<Account> userManager) : IAccountRepository
    {
        public Task CreateAsync(Account account, string password) =>
            userManager.CreateAsync(account, password);

        public Task<Account?> GetByIdAsync(Guid id) =>
            userManager.FindByIdAsync(id.ToString());

        public async Task<Account?> GetByEmailOrUserName(string key) =>
            await userManager.FindByEmailAsync(key) ??
            await userManager.FindByNameAsync(key);

        public async Task<bool> ExistAsync(string email) =>
            await userManager.FindByEmailAsync(email) != null;

        public Task<bool> CheckPasswordAsync(Account account, string password) =>
            userManager.CheckPasswordAsync(account, password);
    }
}
