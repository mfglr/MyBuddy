using AuthServer.Domain;
using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;

namespace AuthServer.Infrastructure.IdentityServer
{
    internal class CustomProfileService(IAccountRepository accountRepository) : IProfileService
    {
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var account =
                await accountRepository.GetByIdAsync(Guid.Parse(context.Subject.GetSubjectId())) ??
                throw new AccountNotFoundException();

            context.IssuedClaims.AddRange(await accountRepository.GetClaimsAsync(account));
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}
