using MassTransit;
using MediatR;
using Shared.Events.MediaService;

namespace VideoTranscoder.Worker.Consumers.TranscodeVideo
{
    internal class TranscodeVideo(ISender sender, Mapper mapper) : IConsumer<TranscodeVideoMessage>
    {
        public Task Consume(ConsumeContext<TranscodeVideoMessage> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
