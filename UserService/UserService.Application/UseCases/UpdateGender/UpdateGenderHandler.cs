using AutoMapper;
using MassTransit;
using MediatR;
using Shared.Events.UserService;
using UserService.Domain;

namespace UserService.Application.UseCases.UpdateGender
{
    internal class UpdateGenderHandler(IMapper mapper, IGrainFactory grainFactory, IPublishEndpoint publishEndpoint,IIdentityService identityService) : IRequestHandler<UpdateGenderRequest>
    {
        public async Task Handle(UpdateGenderRequest request, CancellationToken cancellationToken)
        {
            var gender = new Gender(request.Gender);
            var userGrain = grainFactory.GetGrain<IUserGrain>(identityService.UserId);
            var user = await userGrain.UpdateGender(gender);

            var @event = mapper.Map<User, UserGenderUpdatedEvent>(user);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
