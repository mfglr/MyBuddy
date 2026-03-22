using CommentLikeQueryService.Domain;
using MassTransit;
using MediatR;
using Shared.Events.Account;

namespace CommentLikeQueryService.Worker.MassTransit.Consumers.UpdateUser_OnAccountMediaCreated
{
    internal class UpdateUser_OnAccountMediaCreated_CommentLikeQueryService(
        ISender sender,
        UpdateUser_OnAccountMediaCreated_Mapper mapper
    ) : IConsumer<AccountMediaCreatedEvent>
    {
        public async Task Consume(ConsumeContext<AccountMediaCreatedEvent> context)
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
