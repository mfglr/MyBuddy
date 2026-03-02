using MassTransit;
using MediatR;
using Shared.Events.MediaService;
using Shared.Events.SharedObjects;

namespace VideoTranscoder.Worker.Consumers.TranscodeVideo
{
    internal class TranscodeVideo(ISender sender, Mapper mapper) : IConsumer<MediaClassificationValidatedEvent>
    {
        public Task Consume(ConsumeContext<MediaClassificationValidatedEvent> context) =>
            context.Message.Type == MediaType.Video && context.Message.Instruction.TranscodingInstruction != null
                ? sender.Send(mapper.Map(context.Message), context.CancellationToken)
                : Task.CompletedTask;
    }
}
