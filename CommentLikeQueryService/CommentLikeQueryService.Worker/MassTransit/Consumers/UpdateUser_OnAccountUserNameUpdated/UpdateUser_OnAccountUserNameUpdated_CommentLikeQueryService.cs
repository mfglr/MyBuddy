using CommentLikeQueryService.Domain;
using MassTransit;
using MediatR;
using Shared.Events.Account;

namespace CommentLikeQueryService.Worker.MassTransit.Consumers.UpdateUser_OnAccountUserNameUpdated
{
    internal class UpdateUser_OnAccountUserNameUpdated_CommentLikeQueryService(
        ISender sender,
        UpdateUser_OnAccountUserNameUpdated_Mapper mapper
    ) : IConsumer<AccountUserNameUpdatedEvent>
    {
        public async Task Consume(ConsumeContext<AccountUserNameUpdatedEvent> context)
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
