using AuthServer.Domain;
using MassTransit;
using MediatR;

namespace AuthServer.Application.UseCases.SetMedia
{
    internal class SetMediaHandler(
        SetMediaMapper mapper,
        IPublishEndpoint publishEndpoint,
        IAccountRepository accountRepository
    ) : IRequestHandler<SetMediaRequest>
    {
        public async Task Handle(SetMediaRequest request, CancellationToken cancellationToken)
        {
            var account = 
                await accountRepository.GetByIdAsync(request.Id) ??
                throw new AccountNotFoundException();
            account.SetMedia(request.BlobName, request.Metadata, request.ModerationResult, request.Thumbnails);

            var @event = mapper.Map(account);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
