using MassTransit;
using MediatR;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.SetModerationResult
{
    internal class SetModerationResult_OnMediaClassified_MediaService(
        SetModerationResult_OnMediaClassified_Mapper mapper,
        ISender sender
    ) : IConsumer<MediaClassifiedEvent>
    {
        public Task Consume(ConsumeContext<MediaClassifiedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
