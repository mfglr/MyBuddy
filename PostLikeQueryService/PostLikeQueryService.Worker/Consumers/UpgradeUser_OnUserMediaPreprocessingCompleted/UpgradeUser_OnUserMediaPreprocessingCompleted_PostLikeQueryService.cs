using MassTransit;
using MediatR;
using Shared.Events.UserService;

namespace PostLikeQueryService.Worker.Consumers.UpgradeUser_OnUserMediaPreprocessingCompleted
{
    internal class UpgradeUser_OnUserMediaPreprocessingCompleted_PostLikeQueryService(ISender sender, UpgradeUser_OnUserMediaPreprocessingCompleted_Mapper mapper) : IConsumer<UserMediaSetEvent>
    {
        public Task Consume(ConsumeContext<UserMediaSetEvent> context)
        {
            var request = mapper.Map(context.Message);
            return sender.Send(request, context.CancellationToken);
        }
    }
}
