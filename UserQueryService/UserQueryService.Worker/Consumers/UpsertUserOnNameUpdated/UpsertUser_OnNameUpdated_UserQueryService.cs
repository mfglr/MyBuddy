using MassTransit;
using Shared.Events.UserService;
using UserQueryService.Shared.Model;

namespace UserQueryService.Worker.Consumers.UpsertUserOnNameUpdated
{
   
    internal class UpsertUser_OnNameUpdated_UserQueryService(IUserRepository userRepository, UpsertUser_OnNameUpdated_Mapper mapper) : IConsumer<NameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<NameUpdatedEvent> context) =>
            userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}
