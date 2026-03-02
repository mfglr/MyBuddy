using Shared.Events.MediaService;
using VideoTranscoder.Application.UseCases.TranscodeVideo;

namespace VideoTranscoder.Worker.Consumers.TranscodeVideo
{
    internal class Mapper
    {
        public TranscodeVideoRequest Map(MediaClassificationValidatedEvent @event) =>
            new(
                @event.ContainerName,
                @event.BlobName,
                @event.Instruction.TranscodingInstruction!.Resolution
            );
    }
}
