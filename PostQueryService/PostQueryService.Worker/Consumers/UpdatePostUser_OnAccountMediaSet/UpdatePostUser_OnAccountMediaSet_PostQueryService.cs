using MassTransit;
using MediatR;
using Shared.Events.Account;

namespace PostQueryService.Worker.Consumers.UpdatePostUser_OnAccountMediaSet
{
    internal class UpdatePostUser_OnAccountMediaSet_PostQueryService(
        ISender sender,
        UpdatePostUser_OnAccountMediaSet_Mapper mapper
    ) : IConsumer<AccountMediaSetEvent>
    {
        public Task Consume(ConsumeContext<AccountMediaSetEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
