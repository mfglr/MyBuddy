namespace AuthServer.Domain
{
    public interface IAccountRepository
    {
        Task<Account?> GetByIdAsync(Guid id);
        Task<bool> CheckPasswordAsync(Account account, string password);
        Task<bool> ExistAsync(string email);
        Task CreateAsync(Account account, string password);
        Task AddRoleToAccountAsync(Account account, string role);
    }
}
