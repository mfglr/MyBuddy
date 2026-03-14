using MassTransit;
using Shared.Events.UserService;
using UserQueryService.Shared.Model;

namespace UserQueryService.Worker.Consumers.UpsertUserOnUserCreated
{
    internal class UpsertUser_OnUserCreated_UserQueryService(IUserRepository userRepository, UpsertUser_OnUserCreated_Mapper mapper) : IConsumer<UserCreatedEvent>
    {
        public Task Consume(ConsumeContext<UserCreatedEvent> context) =>
            userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}
