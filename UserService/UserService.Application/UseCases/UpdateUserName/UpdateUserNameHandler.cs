using MassTransit;
using MediatR;
using UserService.Domain;

namespace UserService.Application.UseCases.UpdateUserName
{
    internal class UpdateUserNameHandler(
        IAuthService authService,
        IUserRepository userRepository,
        IPublishEndpoint publishEndpoint,
        UpdateUserNameMapper mapper,
        IIdentityService identityService
    ) : IRequestHandler<UpdateUserNameRequest>
    {
        public async Task Handle(UpdateUserNameRequest request, CancellationToken cancellationToken)
        {
            var userId = identityService.UserId;
            var userName = new UserName(request.UserName);
            var user = await userRepository.GetByIdAsync(userId, cancellationToken) ?? throw new UserNotFoundException();

            await authService.UpdateUserName(userId, userName.Value, cancellationToken);
            user.UpdateUserName(userName);
            await userRepository.UpdateAsync(user, cancellationToken);

            var @event = mapper.Map(user);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
