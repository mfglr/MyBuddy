using AuthServer.Domain;
using Duende.IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AuthServer.Infrastructure.IdentityFramework
{
    internal class AccountRepository(UserManager<Account> userManager) : IAccountRepository
    {
        public Task CreateAsync(Account account, string password) =>
            userManager.CreateAsync(account, password);

        public Task UpdateAsync(Account account) =>
            userManager.UpdateAsync(account);

        public Task<Account?> GetByIdAsync(Guid id) =>
            userManager.FindByIdAsync(id.ToString());

        public async Task<Account?> GetByEmailOrUserName(string key) =>
            await userManager.FindByEmailAsync(key) ?? await userManager.FindByNameAsync(key);

        public async Task<bool> ExistAsync(Email email) =>
            await userManager.FindByEmailAsync(email.Value) != null;

        public async Task<bool> ExistAsync(UserName userName) =>
            await userManager.FindByNameAsync(userName.Value) != null;

        public Task<bool> CheckPasswordAsync(Account account, string password) =>
            userManager.CheckPasswordAsync(account, password);

        public Task AddRoleToAccountAsync(Account account,string role) =>
            userManager.AddToRoleAsync(account, role);

        public async Task<List<Claim>> GetClaimsAsync(Account account)
        {
            var list = new List<Claim>();
            var roles = await userManager.GetRolesAsync(account);

            list.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));
            list.Add(new Claim(ClaimTypes.Gender, account.Gender.Value));
            list.Add(new Claim(JwtClaimTypes.PreferredUserName, account.UserName!));
            if (account.Name != null)
                list.Add(new Claim(ClaimTypes.Name, account.Name.Value));
            return list;
        }
    }
}
