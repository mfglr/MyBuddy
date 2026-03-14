using MassTransit;
using MediatR;
using UserService.Domain;

namespace UserService.Application.UseCases.CreateMedia
{
    internal class CreateMediaHandler(
        CreateMediaMapper mapper,
        IBlobService blobService,
        IUserRepository userRepository,
        IPublishEndpoint publishEndpoint,
        MediaTypeExtractor mediaTypeExtractor,
        IAuthService authService,
        MediaInstructionGenerator mediaInstructionGenerator
    ) : IRequestHandler<CreateMediaRequest>
    {
        public async Task Handle(CreateMediaRequest request, CancellationToken cancellationToken)
        {
            var userId = authService.UserId;
            var user = await userRepository.GetByIdAsync(userId,cancellationToken) ?? throw new UserNotFoundException();

            string? blobName = null;
            try
            {
                var type = mediaTypeExtractor.Extract(request.Media);
                blobName = await blobService.UploadAsync(User.MediaContainerName, request.Media, cancellationToken);
                var media = new Media(blobName, type, mediaInstructionGenerator.Generate());
                user.CreateMedia(media);
                await userRepository.UpdateAsync(user, cancellationToken);

                var @event = mapper.Map(user, media);
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
