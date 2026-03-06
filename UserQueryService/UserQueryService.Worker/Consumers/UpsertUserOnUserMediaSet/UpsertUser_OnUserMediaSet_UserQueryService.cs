using MassTransit;
using Shared.Events.UserService;
using UserQueryService.Shared.Model;

namespace UserQueryService.Worker.Consumers.UpsertUserOnUserMediaSet
{
    internal class UpsertUser_OnUserMediaSet_UserQueryService(IUserRepository userRepository, UpsertUser_OnUserMediaSet_Mapper mapper) : IConsumer<UserMediaSetEvent>
    {
        public Task Consume(ConsumeContext<UserMediaSetEvent> context) =>
            context.Message.IsValidVersion
                ? userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken)
                : Task.CompletedTask;
    }
}
