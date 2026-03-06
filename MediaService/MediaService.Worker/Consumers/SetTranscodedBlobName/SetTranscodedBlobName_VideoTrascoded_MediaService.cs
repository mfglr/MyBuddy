using MassTransit;
using MediatR;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.SetTranscodedBlobName
{
    internal class SetTranscodedBlobName_VideoTrascoded_MediaService(ISender sender, SetTranscodedBlobName_VideoTrascoded_Mapper mapper) : IConsumer<VideoTrascodedEvent>
    {
        public Task Consume(ConsumeContext<VideoTrascodedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
