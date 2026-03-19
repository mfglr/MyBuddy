using MassTransit;
using MediatR;
using Shared.Events.Account;

namespace MediaService.Worker.Consumers.CreateMedia_OnAccountMediaCreated
{
    internal class CreateMedia_OnAccountMediaCreated_MediaService(
        ISender sender,
        CreateMedia_OnAccountMediaCreated_Mapper mapper
    ) : IConsumer<AccountMediaCreatedEvent>
    {
        public Task Consume(ConsumeContext<AccountMediaCreatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
