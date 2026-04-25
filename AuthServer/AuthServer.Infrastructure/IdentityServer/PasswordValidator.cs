using AuthServer.Application;
using AuthServer.Domain;
using Duende.IdentityServer.Validation;

namespace AuthServer.Infrastructure.IdentityServer
{
    internal class PasswordValidator(IAccountRepository accountRepository) : IResourceOwnerPasswordValidator
    {
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var account = await accountRepository.GetByEmailOrUserName(context.UserName) ?? throw new AccountNotFoundException();

            if (!await accountRepository.CheckPasswordAsync(account, context.Password))
                throw new InvalidCredentials();

            context.Result = new GrantValidationResult(
                subject: account.Id,
                authenticationMethod: "custom",
                claims: await accountRepository.GetClaimsAsync(account)
            );
        }
    }
}
