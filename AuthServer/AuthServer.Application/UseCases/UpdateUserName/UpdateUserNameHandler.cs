using AuthServer.Domain;
using MassTransit;
using MediatR;

namespace AuthServer.Application.UseCases.UpdateUserName
{
    internal class UpdateUserNameHandler(
        UpdateUserNameMapper mapper,
        IAuthService authService,
        IAccountRepository accountRepository,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<UpdateUserNameRequest>
    {
        public async Task Handle(UpdateUserNameRequest request, CancellationToken cancellationToken)
        {
            var userName = new UserName(request.UserName);
            var account = 
                await accountRepository.GetByIdAsync(authService.UserId) ??
                throw new AccountNotFoundException();

            account.UpdateUserName(userName);

            var @event = mapper.Map(account);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
