using MassTransit;
using MediatR;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.AddTranscoding
{
    internal class AddTranscoding_OnVideoTrascoded_MediaService(ISender sender, AddTranscoding_OnVideoTrascoded_Mapper mapper) : IConsumer<VideoTrascodedEvent>
    {
        public Task Consume(ConsumeContext<VideoTrascodedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
