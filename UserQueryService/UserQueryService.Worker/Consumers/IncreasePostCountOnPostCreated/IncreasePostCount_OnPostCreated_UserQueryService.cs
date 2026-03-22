using MassTransit;
using Shared.Events.PostService;
using UserQueryService.Shared.Model;

namespace UserQueryService.Worker.Consumers.IncreasePostCountOnPostCreated
{
    internal class IncreasePostCount_OnPostCreated_UserQueryService(IUserRepository userRepository) : IConsumer<PostCreatedEvent>
    {
        public Task Consume(ConsumeContext<PostCreatedEvent> context) =>
            userRepository.IncreasePostCount(context.Message.UserId, context.CancellationToken);
    }
}
