using MassTransit;
using Shared.Events.PostService;
using UserQueryService.Shared.Model;

namespace UserQueryService.Worker.Consumers.IncreasePostCountOnPostRestored
{
    internal class IncreasePostCount_OnPostRestored_UserQueryService(IUserRepository userRepository) : IConsumer<PostRestoredEvent>
    {
        public Task Consume(ConsumeContext<PostRestoredEvent> context) =>
            userRepository.IncreasePostCount(context.Message.UserId, context.CancellationToken);
    }
}
