using AuthServer.Domain;
using MassTransit;
using MediatR;

namespace AuthServer.Application.UseCases.CreateAccount
{
    internal class CreateAccountHandler(
        CreateAccountMapper mapper,
        AccountCreatorDomainService accountCreator,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<CreateAccountRequest, CreateAccountResponse>
    {
        public async Task<CreateAccountResponse> Handle(CreateAccountRequest request, CancellationToken cancellationToken)
        {
            var email = new Email(request.Email);
            var account = await accountCreator.Create(email, request.Password);

            var id = Guid.Parse(account.Id);
            var @event = mapper.Map(account);
            await publishEndpoint.Publish(@event, cancellationToken);

            return new(id,account.UserName!);
        }
    }
}
