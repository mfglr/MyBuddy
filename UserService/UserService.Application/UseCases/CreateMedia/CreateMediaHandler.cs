using MassTransit;
using MediatR;
using Shared.Events.UserService;
using UserService.Domain;

namespace UserService.Application.UseCases.CreateMedia
{
    internal class CreateMediaHandler(IBlobService blobService, IGrainFactory grainFactory, IPublishEndpoint publishEndpoint, MediaTypeValidator mediaTypeExtractor, IIdentityService idendityService) : IRequestHandler<CreateMediaRequest>
    {
        public async Task Handle(CreateMediaRequest request, CancellationToken cancellationToken)
        {
            mediaTypeExtractor.Validate(request.Media);

            var userId = idendityService.UserId;
            var userGrain = grainFactory.GetGrain<IUserGrain>(userId);
            string? blobName = null;
            try
            {
                blobName = await blobService.UploadAsync(User.MediaContainerName, request.Media, cancellationToken);
                var media = new Media(blobName);
                await userGrain.CreateMedia(media);
                
                var @event = new UserMediaCreatedEvent(userId, media.ContainerName, media.BlobName);
                await publishEndpoint.Publish(@event, cancellationToken);
            }
            catch (Exception)
            {
                if(blobName != null)
                    await blobService.DeleteAsync(User.MediaContainerName, blobName, cancellationToken);
                throw;
            }
        }
    }
}
