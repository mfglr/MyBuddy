using MassTransit;
using MediatR;
using Shared.Events.Account;

namespace CommentLikeQueryService.Worker.MassTransit.Consumers.UpsertUser_OnAccountCreated
{
    internal class UpsertUser_OnAccountCreated_CommentLikeQueryService(
        ISender sender,
        UpsertUser_OnAccountCreated_Mapper mapper
    ) : IConsumer<AccountCreatedEvent>
    {
        public Task Consume(ConsumeContext<AccountCreatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
