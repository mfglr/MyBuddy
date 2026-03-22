using CommentQueryService.Domain;
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
        public async Task Consume(ConsumeContext<AccountNameUpdatedEvent> context)
        {
            try
            {
                await sender.Send(mapper.Map(context.Message), context.CancellationToken);
            }
            catch (OutdatedVersionException)
            {
                return;
            }
        }
    }
}
