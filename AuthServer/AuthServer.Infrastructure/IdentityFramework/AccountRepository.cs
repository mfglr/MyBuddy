using AuthServer.Domain;
using AuthServer.Infrastructure.PostgreSql;
using Duende.IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace AuthServer.Infrastructure.IdentityFramework
{
    internal class AccountRepository(UserManager<Account> userManager, SqlContext context) : IAccountRepository
    {
        private static JsonSerializerOptions _options = new()
        {
            TypeInfoResolver = new DefaultJsonTypeInfoResolver
            {
                Modifiers = { typeInfo => {
                    if (typeInfo.Type == typeof(Media.Models.Media))
                    {
                        var prop1 = typeInfo.Properties.FirstOrDefault(p => p.Name == nameof(Media.Models.Media.ContainerName));
                        prop1?.ShouldSerialize = (_, _) => false;

                        var prop2 = typeInfo.Properties.FirstOrDefault(p => p.Name == nameof(Media.Models.Media.BlobName));
                        prop2?.ShouldSerialize = (_, _) => false;

                        var prop3 = typeInfo.Properties.FirstOrDefault(p => p.Name == nameof(Media.Models.Media.Type));
                        prop3?.ShouldSerialize = (_, _) => false;

                        var prop4 = typeInfo.Properties.FirstOrDefault(p => p.Name == nameof(Media.Models.Media.Metadata));
                        prop4?.ShouldSerialize = (_, _) => false;

                        var prop5 = typeInfo.Properties.FirstOrDefault(p => p.Name == nameof(Media.Models.Media.Transcodings));
                        prop5?.ShouldSerialize = (_, _) => false;

                        var prop6 = typeInfo.Properties.FirstOrDefault(p => p.Name == nameof(Media.Models.Media.Instruction));
                        prop6?.ShouldSerialize = (_, _) => false;
                    }
                }}
            }
        };

        public Task CreateAsync(Account account, string password) =>
            userManager.CreateAsync(account, password);

        public Task UpdateAsync(Account account) =>
            userManager.UpdateAsync(account);

        public Task<List<Account>> GetDeletedAccounts(TimeSpan timeSpan, CancellationToken cancellationToken)
        {
            var dateTime = DateTime.UtcNow.Subtract(timeSpan);
            return context.Users.Where(x => x.DeletedAt != null && x.DeletedAt <= dateTime).ToListAsync(cancellationToken);
        }

        public void Delete(IEnumerable<Account> accounts) =>
            context.Users.RemoveRange(accounts);

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
            list.Add(new Claim(ClaimTypes.Version, account.Version.ToString()));
            if (account.Name != null)
                list.Add(new Claim(ClaimTypes.Name, account.Name.Value));
            if (account.Picture != null)
                list.Add(new Claim(
                    JwtClaimTypes.Picture,
                    JsonSerializer.Serialize(account.Picture,options: _options)
                ));
            return list;
        }
    }
}
