using AuthServer.Domain;
using MassTransit;
using MediatR;

namespace AuthServer.Application.UseCases.UpdateName
{
    internal class UpdateNameHandler(
        IAccountRepository accountRepository,
        IPublishEndpoint publishEndpoint,
        IAuthService authService,
        UpdateNameMapper mapper
    ) : IRequestHandler<UpdateNameRequest>
    {
        public async Task Handle(UpdateNameRequest request, CancellationToken cancellationToken)
        {
            var name = new Name(request.Name);
            var account =
                await accountRepository.GetByIdAsync(authService.UserId) ??
                throw new AccountNotFoundException();
            account.UpdateName(name);

            var @event = mapper.Map(account);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
