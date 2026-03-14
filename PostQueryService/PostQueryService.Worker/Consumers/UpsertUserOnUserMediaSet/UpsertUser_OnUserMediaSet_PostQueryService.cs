using MassTransit;
using PostQueryService.Shared.Model;
using Shared.Events.UserService;

namespace PostQueryService.Worker.Consumers.UpsertUserOnUserMediaSet
{
    internal class UpsertUser_OnUserMediaSet_PostQueryService(
        UpsertUser_OnUserMediaSet_Mapper mapper,
        IUserRepository userRepository
    ) : IConsumer<UserMediaSetEvent>
    {
        public Task Consume(ConsumeContext<UserMediaSetEvent> context) =>
            userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}
