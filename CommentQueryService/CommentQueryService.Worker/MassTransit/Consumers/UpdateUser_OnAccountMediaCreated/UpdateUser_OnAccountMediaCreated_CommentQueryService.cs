using CommentQueryService.Domain;
using MassTransit;
using MediatR;
using Shared.Events.Account;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpdateUser_OnAccountMediaCreated
{
    internal class UpdateUser_OnAccountMediaCreated_CommentQueryService(
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
