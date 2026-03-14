using MassTransit;
using MediatR;
using UserService.Domain;

namespace UserService.Application.UseCases.UpdateUserName
{
    internal class UpdateUserNameHandler(
        UserNameUpdaterDomainService userNameUpdater,
        IUserRepository userRepository,
        IPublishEndpoint publishEndpoint,
        UpdateUserNameMapper mapper,
        IAuthService identityService
    ) : IRequestHandler<UpdateUserNameRequest>
    {
        public async Task Handle(UpdateUserNameRequest request, CancellationToken cancellationToken)
        {
            var userId = identityService.UserId;
            var userName = new UserName(request.UserName);
            var user = await userRepository.GetByIdAsync(userId, cancellationToken) ?? throw new UserNotFoundException();
            await userNameUpdater.UpdateAsync(user, userName,cancellationToken);

            await userRepository.UpdateAsync(user, cancellationToken);

            var @event = mapper.Map(user);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
