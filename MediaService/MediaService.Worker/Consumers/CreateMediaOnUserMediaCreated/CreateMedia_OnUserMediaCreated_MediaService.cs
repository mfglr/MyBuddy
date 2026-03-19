using MassTransit;
using MediatR;
using Shared.Events.Account;

namespace MediaService.Worker.Consumers.CreateMediaOnUserMediaCreated
{
    internal class CreateMedia_OnUserMediaCreated_MediaService(
        ISender sender,
        CreateMedia_OnUserMediaCreated_Mapper mapper
    ) : IConsumer<AccountCreatedEvent>
    {
        public Task Consume(ConsumeContext<AccountCreatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
