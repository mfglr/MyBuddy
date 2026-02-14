using AutoMapper;
using MassTransit;
using MediatR;
using Shared.Events.UserService;

namespace PostLikeQueryService.Worker.Consumers.UpgradeUser_OnUserNameUpdated
{
    internal class UpgradeUser_OnUserNameUpdated_PostLikeQueryService(ISender sender, Mapper mapper) : IConsumer<UserNameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<UserNameUpdatedEvent> context)
        {
            var request = mapper.Map(context.Message);
            return sender.Send(request,context.CancellationToken);
        }
    }
}
