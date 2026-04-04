using MassTransit;
using MediatR;
using Shared.Events.Account;

namespace PostQueryService.Worker.Consumers.UpsertUser_OnAccountMediaSet
{
    internal class UpsertUser_OnAccountMediaSet_PostQueryService(
        ISender sender,
        UpsertUser_OnAccountMediaSet_Mapper mapper
    ) : IConsumer<AccountMediaSetEvent>
    {
        public Task Consume(ConsumeContext<AccountMediaSetEvent> context) =>
            sender.Send(mapper.Map(context.Message),context.CancellationToken);
    }
}
