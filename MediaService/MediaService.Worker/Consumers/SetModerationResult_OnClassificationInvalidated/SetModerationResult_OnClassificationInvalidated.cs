using MassTransit;
using MediatR;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.SetModerationResult_OnClassificationInvalidated
{
    internal class SetModerationResult_OnClassificationInvalidated(Mapper mapper, ISender sender) : IConsumer<MediaClassificationInvalidatedEvent>
    {
        public Task Consume(ConsumeContext<MediaClassificationInvalidatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
