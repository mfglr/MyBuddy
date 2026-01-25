using AutoMapper;
using MassTransit;
using MediatR;
using Shared.Events.UserService;
using UserService.Domain;

namespace UserService.Application.UseCases.UpdateName
{
    internal class UpdateNameHandler(IUserRepository userRepository, IPublishEndpoint publishEndpoint, IMapper mapper, IIdentityService identityService) : IRequestHandler<UpdateNameRequest>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;
        private readonly IIdentityService _identityService = identityService;

        public async Task Handle(UpdateNameRequest request, CancellationToken cancellationToken)
        {
            var userId = _identityService.UserId;
            var user =
                await _userRepository.GetByIdAsync(userId, cancellationToken) ??
                throw new UserNotFoundException();

            var name = new Name(request.Name);
            user.UpdateName(name);
            await _userRepository.UpdateAsync(user, cancellationToken);

            var @event = _mapper.Map<User, NameUpdatedEvent>(user);
            await _publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
