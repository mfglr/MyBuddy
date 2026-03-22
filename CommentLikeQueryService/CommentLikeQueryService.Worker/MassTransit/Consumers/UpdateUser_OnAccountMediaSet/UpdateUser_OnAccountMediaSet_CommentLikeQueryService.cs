using CommentLikeQueryService.Domain;
using MassTransit;
using MediatR;
using Shared.Events.Account;

namespace CommentLikeQueryService.Worker.MassTransit.Consumers.UpdateUser_OnAccountMediaSet
{
    internal class UpdateUser_OnAccountMediaSet_CommentLikeQueryService(
        ISender sender,
        UpdateUser_OnAccountMediaSet_Mapper mapper
    ) : IConsumer<AccountMediaSetEvent>
    {
        public async Task Consume(ConsumeContext<AccountMediaSetEvent> context)
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
