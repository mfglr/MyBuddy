using MassTransit;
using MediatR;
using UserService.Domain;

namespace UserService.Application.UseCases.SetMedia
{
    internal class SetMediaHandler(
        SetMediaMapper mapper,
        IPublishEndpoint publishEndpoint,
        IUserRepository userRepository
    ) : IRequestHandler<SetMediaRequest>
    {
        public async Task Handle(SetMediaRequest request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(request.Id,cancellationToken) ?? throw new UserNotFoundException();
            user.SetMedia(request.BlobName, request.Metadata, request.ModerationResult, request.Thumbnails);
            await userRepository.UpdateAsync(user, cancellationToken);

            var @event = mapper.Map(user);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
