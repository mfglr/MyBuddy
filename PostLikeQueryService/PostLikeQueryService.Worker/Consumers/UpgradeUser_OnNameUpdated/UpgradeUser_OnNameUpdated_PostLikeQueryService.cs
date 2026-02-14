using MassTransit;
using MediatR;
using Shared.Events.UserService;

namespace PostLikeQueryService.Worker.Consumers.UpgradeUser_OnNameUpdated
{
    internal class UpgradeUser_OnNameUpdated_PostLikeQueryService(ISender sender, UpgradeUser_OnNameUpdated_Mapper mapper) : IConsumer<NameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<NameUpdatedEvent> context)
        {
            var request = mapper.Map(context.Message);
            return sender.Send(request, context.CancellationToken);
        }
    }
}
