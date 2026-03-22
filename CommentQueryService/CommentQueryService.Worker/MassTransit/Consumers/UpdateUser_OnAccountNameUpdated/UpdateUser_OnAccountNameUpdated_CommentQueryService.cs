using MassTransit;
using MediatR;
using Shared.Events.Account;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpdateUser_OnAccountNameUpdated
{
    internal class UpdateUser_OnAccountNameUpdated_CommentQueryService(
        UpdateUser_OnAccountNameUpdated_Mapper mapper,
        ISender sender
    ) : IConsumer<AccountNameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<AccountNameUpdatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
