using System.Security.Claims;

namespace AuthServer.Domain
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetDeletedAccounts(TimeSpan timeSpan, CancellationToken cancellationToken);
        Task<Account?> GetByIdAsync(Guid id);
        Task<Account?> GetByEmailOrUserName(string key);
        Task UpdateAsync(Account account);
        void Delete(IEnumerable<Account> accounts);
        Task<bool> CheckPasswordAsync(Account account, string password);
        Task<bool> ExistAsync(Email email);
        Task<bool> ExistAsync(UserName userName);
        Task CreateAsync(Account account, string password);
        Task AddRoleToAccountAsync(Account account, string role);
        Task<List<Claim>> GetClaimsAsync(Account account);
    }
}
