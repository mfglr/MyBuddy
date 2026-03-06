using MassTransit;
using PostQueryService.Shared.Model;
using Shared.Events.UserService;

namespace PostQueryService.Worker.Consumers.UpsertUserOnUserNameUpdated
{
    internal class UpsertUser_OnUserNameUpdated_PostQueryService(UpsertUserOn_UserNameUpdated_Mapper mapper, IUserRepository userRepository) : IConsumer<UserNameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<UserNameUpdatedEvent> context)
        {
            if (!context.Message.IsValidVersion) return Task.CompletedTask;
            var user = mapper.Map(context.Message);
            return userRepository.UpsertAsync(user, context.CancellationToken);
        }
    }
}
