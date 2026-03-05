using MassTransit;
using MediatR;
using UserService.Domain;

namespace UserService.Application.UseCases.UpdateName
{
    internal class UpdateNameHandler(
        IUserRepository userRepository,
        IPublishEndpoint publishEndpoint,
        UpdateNameMapper mapper,
        IIdentityService identityService
    ) : IRequestHandler<UpdateNameRequest>
    {
        public async Task Handle(UpdateNameRequest request, CancellationToken cancellationToken)
        {
            var userId = identityService.UserId;
            var name = new Name(request.Name);
            var user = await userRepository.GetByIdAsync(userId, cancellationToken) ?? throw new UserNotFoundException();
            user.UpdateName(name);
            await userRepository.UpdateAsync(user, cancellationToken);

            var @event = mapper.Map(user);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
