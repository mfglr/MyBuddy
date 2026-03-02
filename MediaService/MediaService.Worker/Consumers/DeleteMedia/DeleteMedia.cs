using MassTransit;
using MediatR;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.DeleteMedia
{
    internal class DeleteMedia(ISender sender, Mapper mapper) : IConsumer<MediaPreprecessingCompletedEvent>
    {
        public Task Consume(ConsumeContext<MediaPreprecessingCompletedEvent> context) =>
            sender.Send(mapper.Map(context.Message),context.CancellationToken);
    }
}
