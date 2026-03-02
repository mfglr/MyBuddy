using MassTransit;
using MediatR;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.SetModerationResult_OnClassificationValidated
{
    internal class SetModerationResult_OnClassificationValidated(Mapper mapper, ISender sender) : IConsumer<MediaClassificationValidatedEvent>
    {
        public Task Consume(ConsumeContext<MediaClassificationValidatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
