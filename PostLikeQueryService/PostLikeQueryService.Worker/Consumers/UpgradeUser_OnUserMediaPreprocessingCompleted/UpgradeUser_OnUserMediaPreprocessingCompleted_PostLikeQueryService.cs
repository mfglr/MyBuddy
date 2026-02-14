using MassTransit;
using MediatR;
using Shared.Events.UserService;

namespace PostLikeQueryService.Worker.Consumers.UpgradeUser_OnUserMediaPreprocessingCompleted
{
    internal class UpgradeUser_OnUserMediaPreprocessingCompleted_PostLikeQueryService(ISender sender, UpgradeUser_OnUserMediaPreprocessingCompleted_Mapper mapper) : IConsumer<UserMediaPreprocessingCompletedEvent>
    {
        public Task Consume(ConsumeContext<UserMediaPreprocessingCompletedEvent> context)
        {
            var request = mapper.Map(context.Message);
            return sender.Send(request, context.CancellationToken);
        }
    }
}
