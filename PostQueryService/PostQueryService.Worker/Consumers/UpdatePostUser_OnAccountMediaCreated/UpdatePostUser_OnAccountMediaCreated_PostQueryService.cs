using MassTransit;
using MediatR;
using Shared.Events.Account;

namespace PostQueryService.Worker.Consumers.UpdatePostUser_OnAccountMediaCreated
{
    internal class UpdatePostUser_OnAccountMediaCreated_PostQueryService(
        ISender sender,
        UpdatePostUser_OnAccountMediaCreated_Mapper mapper
    ) : IConsumer<AccountMediaCreatedEvent>
    {
        public Task Consume(ConsumeContext<AccountMediaCreatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
