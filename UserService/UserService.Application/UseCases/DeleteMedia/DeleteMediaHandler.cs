using MassTransit;
using MediatR;
using UserService.Domain;

namespace UserService.Application.UseCases.DeleteMedia
{
    internal class DeleteMediaHandler(
        IUserRepository userRepsitory,
        IPublishEndpoint publishEndpoint,
        DeleteMediaMapper mapper,
        IAuthService authService
    ) : IRequestHandler<DeleteMediaRequest>
    {
        public async Task Handle(DeleteMediaRequest request, CancellationToken cancellationToken)
        {
            var userId = authService.UserId;
            var user = await userRepsitory.GetByIdAsync(userId, cancellationToken) ?? throw new UserNotFoundException();

            var mediaDeleted = user.DeleteMedia(request.BlobName);
            await userRepsitory.UpdateAsync(user, cancellationToken);

            var @event = mapper.Map(user, mediaDeleted);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
