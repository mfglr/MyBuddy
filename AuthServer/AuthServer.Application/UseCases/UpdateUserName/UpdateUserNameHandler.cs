using AuthServer.Domain;
using MassTransit;
using MediatR;

namespace AuthServer.Application.UseCases.UpdateUserName
{
    internal class UpdateUserNameHandler(
        IAccountRepository accountRepository,
        UserNameUpdaterDomainService userNameUpdater,
        IPublishEndpoint publishEndpoint,
        UpdateUserNameMapper mapper,
        IAuthService authService
    ) : IRequestHandler<UpdateUserNameRequest>
    {
        public async Task Handle(UpdateUserNameRequest request, CancellationToken cancellationToken)
        {
            var userName = new UserName(request.UserName);
            var account = await accountRepository.GetByIdAsync(authService.UserId) ?? throw new AccountNotFoundException();
            await userNameUpdater.UpdateAsync(account, userName);
            await accountRepository.UpdateAsync(account);

            var @event = mapper.Map(account);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
