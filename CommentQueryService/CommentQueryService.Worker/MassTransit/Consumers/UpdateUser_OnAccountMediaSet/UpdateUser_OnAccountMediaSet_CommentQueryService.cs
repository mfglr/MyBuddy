using MassTransit;
using MediatR;
using Shared.Events.Account;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpdateUser_OnAccountMediaSet
{
    internal class UpdateUser_OnAccountMediaSet_CommentQueryService(
        UpsertUser_OnAccountMediaSet_Mapper mapper,
        ISender sender
    ) : IConsumer<AccountMediaSetEvent>
    {
        public Task Consume(ConsumeContext<AccountMediaSetEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
