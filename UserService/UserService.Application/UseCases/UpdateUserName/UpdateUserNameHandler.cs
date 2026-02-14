using AutoMapper;
using MassTransit;
using MediatR;
using Shared.Events.UserService;
using UserService.Domain;

namespace UserService.Application.UseCases.UpdateUserName
{
    internal class UpdateUserNameHandler(IAuthService authService, IGrainFactory grainFactory, IPublishEndpoint publishEndpoint, IMapper mapper, IIdentityService identityService) : IRequestHandler<UpdateUserNameRequest>
    {
        public async Task Handle(UpdateUserNameRequest request, CancellationToken cancellationToken)
        {
            var userId = identityService.UserId;
            var userName = new UserName(request.UserName);
            
            await authService.UpdateUserName(userId, userName.Value, cancellationToken);
            
            var userGrain = grainFactory.GetGrain<IUserGrain>(userId);
            var user = await userGrain.UpdateUserName(userName);

            var @event = mapper.Map<User, UserNameUpdatedEvent>(user);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
