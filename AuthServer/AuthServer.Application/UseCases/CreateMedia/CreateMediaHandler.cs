using AuthServer.Domain;
using MassTransit;
using Media.Models;
using MediatR;

namespace AuthServer.Application.UseCases.CreateMedia
{
    internal class CreateMediaHandler(
        IAccountRepository accountRepository,
        IPublishEndpoint publishEndpoint,
        IAuthService authService,
        CreateMediaMapper mapper,
        MediaInstructionGenerator mediaInstructionGenerator,
        MediaTypeExtractor mediaTypeExtractor,
        IBlobService blobService
    ) : IRequestHandler<CreateMediaRequest>
    {
        public async Task Handle(CreateMediaRequest request, CancellationToken cancellationToken)
        {
            var userId = authService.UserId;
            var account = await accountRepository.GetByIdAsync(userId) ?? throw new AccountNotFoundException();

            string? blobName = null;
            try
            {
                var type = mediaTypeExtractor.Extract(request.Media);
                blobName = await blobService.UploadAsync(Account.MediaContainerName, request.Media, cancellationToken);
                var media = new AccountMedia(Account.MediaContainerName, blobName, MediaProcessingContext.Create(type,mediaInstructionGenerator.Generate()));
                account.CreateMedia(media);

                var @event = mapper.Map(account, media);
                await publishEndpoint.Publish(@event, cancellationToken);
            }
            catch (Exception)
            {
                if (blobName != null)
                    await blobService.DeleteAsync(Account.MediaContainerName, blobName, cancellationToken);
                throw;
            }
        }
    }
}
