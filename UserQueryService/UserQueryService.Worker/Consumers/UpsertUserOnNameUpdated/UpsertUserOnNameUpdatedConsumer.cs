using MassTransit;
using Shared.Events.UserService;
using UserQueryService.Shared.Model;

namespace UserQueryService.Worker.Consumers.UpsertUserOnNameUpdated
{
   
    internal class UpsertUserOnNameUpdatedConsumer(IUserRepository userRepository, UpsertUserOnNameUpdatedMapper mapper) : IConsumer<NameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<NameUpdatedEvent> context) =>
            context.Message.IsValidVersion
                ? userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken)
                : Task.CompletedTask;
    }
}
