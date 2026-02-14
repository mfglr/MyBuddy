using MassTransit;
using MediatR;
using Shared.Events.UserService;

namespace PostLikeQueryService.Worker.Consumers.UpgradeUser_OnUserCreated
{
    internal class UpgradeUser_OnUserCreated_PostLikeQueryService(ISender sender, Mapper mapper) : IConsumer<UserCreatedEvent>
    {
        public Task Consume(ConsumeContext<UserCreatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
