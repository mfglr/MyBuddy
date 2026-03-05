using MassTransit;
using Shared.Events.UserService;
using UserQueryService.Shared.Model;

namespace UserQueryService.Worker.Consumers.UpsertUserOnUserCreated
{
    internal class UpsertUserOnUserCreatedConsumer(IUserRepository userRepository, UpsertUserOnUserCreatedMapper mapper) : IConsumer<UserCreatedEvent>
    {
        public Task Consume(ConsumeContext<UserCreatedEvent> context) =>
            context.Message.IsValidVersion
                ? userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken)
                : Task.CompletedTask;
    }
}
