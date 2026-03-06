using MassTransit;
using PostQueryService.Shared.Model;
using Shared.Events.UserService;

namespace PostQueryService.Worker.Consumers.UpsertUserOnNameUpdated
{
    internal class UpsertUser_OnNameUpdated_PostQueryService(UpsertUser_OnNameUpdated_Mapper mapper,IUserRepository userRepository) : IConsumer<NameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<NameUpdatedEvent> context)
        {
            if (!context.Message.IsValidVersion) return Task.CompletedTask;
            var user = mapper.Map(context.Message);
            return userRepository.UpsertAsync(user, context.CancellationToken);
        }
    }
}
