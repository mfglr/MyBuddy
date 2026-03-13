using AuthServer.Domain;
using MassTransit;
using MediatR;
using Shared.Events.Account;

namespace AuthServer.Application.UseCases.UpdateEmail
{
    internal class UpdateEmailHandler(
        IPublishEndpoint publishEndpoint,
        IAccountRepository accountRepository,
        IAuthService authService
    ) : IRequestHandler<UpdateEmailRequest>
    {
        public async Task Handle(UpdateEmailRequest request, CancellationToken cancellationToken)
        {
            var email = new Email(request.Email);
            var account = 
                await accountRepository.GetByIdAsync(authService.UserId) ??
                throw new AccountNotFoundException();
            
            account.UpdateEmail(email);

            var @event = new AccountEmailUpdatedEvent(authService.UserId, request.Email);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
