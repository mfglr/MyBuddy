using AuthServer.Domain;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AuthServer.Infrastructure.IdentityServer
{
    internal class CustomProfileService(UserManager<Account> userManager) : IProfileService
    {
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = 
                await userManager.GetUserAsync(context.Subject) ??
                throw new Exception();

            var roles = await userManager.GetRolesAsync(user);

            foreach (var role in roles)
                context.IssuedClaims.Add(new Claim(ClaimTypes.Role, role));
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}
