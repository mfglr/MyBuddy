using CommentLikeQueryService.Domain;
using MassTransit;
using MediatR;
using Shared.Events.Account;

namespace CommentLikeQueryService.Worker.MassTransit.Consumers.UpdateUser_OnAccountNameUpdated
{
    internal class UpdateUser_OnAccountNameUpdated_CommentLikeQueryService(
        ISender sender,
        UpdateUser_OnAccountNameUpdated_Mapper mapper
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
