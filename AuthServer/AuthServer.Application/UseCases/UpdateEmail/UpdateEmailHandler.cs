using AuthServer.Domain;
using MassTransit;
using MediatR;

namespace AuthServer.Application.UseCases.UpdateEmail
{
    internal class UpdateEmailHandler(
        IPublishEndpoint publishEndpoint,
        IAccountRepository accountRepository,
        UpdateEmailMapper mapper,
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

            var @event = mapper.Map(account);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
