using MassTransit;
using Shared.Events.UserService;
using UserQueryService.Shared.Model;

namespace UserQueryService.Worker.Consumers.UpsertUserOnUserNameUpdated
{
    internal class UpsertUserOnUserNameUpdatedConsumer(
        IUserRepository userRepository,
        UpsertUserOnUserNameUpdatedMapper mapper
    ) : IConsumer<UserNameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<UserNameUpdatedEvent> context) =>
            context.Message.IsValidVersion
                ? userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken)
                : Task.CompletedTask;
    }
}
