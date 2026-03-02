using MassTransit;
using MediatR;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.SetTranscodedBlobName
{
    internal class SetTranscodedBlobName(ISender sender, Mapper mapper) : IConsumer<VideoTrascodedEvent>
    {
        public Task Consume(ConsumeContext<VideoTrascodedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
