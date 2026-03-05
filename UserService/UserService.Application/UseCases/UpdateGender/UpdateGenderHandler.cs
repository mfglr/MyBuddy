using MassTransit;
using MediatR;
using UserService.Domain;

namespace UserService.Application.UseCases.UpdateGender
{
    internal class UpdateGenderHandler(
        UpdateGenderMapper mapper,
        IUserRepository userRepository,
        IPublishEndpoint publishEndpoint,
        IIdentityService identityService
    ) : IRequestHandler<UpdateGenderRequest>
    {
        public async Task Handle(UpdateGenderRequest request, CancellationToken cancellationToken)
        {
            var userId = identityService.UserId;
            var gender = new Gender(request.Gender);
            var user = await userRepository.GetByIdAsync(userId, cancellationToken) ?? throw new UserNotFoundException();
            user.UpdateGender(gender);
            await userRepository.UpdateAsync(user, cancellationToken);

            var @event = mapper.Map(user);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
