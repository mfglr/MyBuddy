using MassTransit;
using MediatR;
using UserService.Domain;

namespace UserService.Application.UseCases.CreateUser
{
    public class CreateUserHandler(
        CreateUserMapper mapper,
        IUserRepository userRepository,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<CreateUserRequest>
    {
        public async Task Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var username = UserName.GenerateRandom();
            var user = new User(request.Id, username);
            await userRepository.CreateAsync(user, cancellationToken);

            var @event = mapper.Map(user);
            await publishEndpoint.Publish(@event,cancellationToken);
        }
    }
}
