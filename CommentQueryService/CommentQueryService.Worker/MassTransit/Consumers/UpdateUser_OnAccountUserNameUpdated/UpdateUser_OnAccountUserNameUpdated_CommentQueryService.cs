using CommentQueryService.Domain;
using MassTransit;
using MediatR;
using Shared.Events.Account;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpdateUser_OnAccountUserNameUpdated
{
    internal class UpdateUser_OnAccountUserNameUpdated_CommentQueryService(
        UpsertUser_OnAccountUserNameUpdated_Mapper mapper,
        ISender sender
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
