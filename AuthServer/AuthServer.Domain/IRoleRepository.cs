using Microsoft.AspNetCore.Identity;

namespace AuthServer.Domain
{
    public interface IRoleRepository
    {
        Task AddAsync(Account account, IdentityRole role);
    }
}
