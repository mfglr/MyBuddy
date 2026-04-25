using AuthServer.Domain;
using MassTransit;
using MediatR;

namespace AuthServer.Application.UseCases.DeleteAccount
{
    internal class DeleteAccountHandler(
        DeleteAccountMapper mapper,
        IAuthService authService,
        IAccountRepository accountRepository,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<DeleteAccountRequest>
    {
        public async Task Handle(DeleteAccountRequest request, CancellationToken cancellationToken)
        {
            var account =
                await accountRepository.GetByIdAsync(authService.UserId) ??
                throw new AccountNotFoundException();
            accountRepository.Delete(account);
            
            var @event = mapper.Map(account);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
