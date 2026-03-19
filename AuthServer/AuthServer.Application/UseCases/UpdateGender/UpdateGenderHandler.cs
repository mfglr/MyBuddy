using AuthServer.Domain;
using MassTransit;
using MediatR;

namespace AuthServer.Application.UseCases.UpdateGender
{
    internal class UpdateGenderHandler(
        IAccountRepository accountRepository,
        IAuthService authService,
        UpdateGenderMapper mapper,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<UpdateGenderRequest>
    {
        public async Task Handle(UpdateGenderRequest request, CancellationToken cancellationToken)
        {
            var gender = new Gender(request.Gender);
            var account = 
                await accountRepository.GetByIdAsync(authService.UserId) ??
                throw new AccountNotFoundException();

            account.UpdateGender(gender);

            var @event = mapper.Map(account);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
