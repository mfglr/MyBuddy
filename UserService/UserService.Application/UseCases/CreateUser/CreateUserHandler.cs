using MassTransit;
using MediatR;
using UserService.Domain;

namespace UserService.Application.UseCases.CreateUser
{
    public class CreateUserHandler(
        CreateUserMapper mapper,
        IUserRepository userRepository,
        IAuthService authService,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<CreateUserRequest>
    {
        public async Task Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var username = UserName.GenerateRandom();
            Guid userId = await authService.RegisterAsync(
                username.Value,
                request.Email,
                request.Password,
                cancellationToken
            );

            var user = new User(userId, username);
            await userRepository.CreateAsync(user, cancellationToken);

            var @event = mapper.Map(user);
            await publishEndpoint.Publish(@event,cancellationToken);
        }
    }
}
