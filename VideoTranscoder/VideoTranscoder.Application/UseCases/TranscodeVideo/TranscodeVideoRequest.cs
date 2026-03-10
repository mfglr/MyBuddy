using MediatR;
using Shared.Events.SharedObjects;

namespace VideoTranscoder.Application.UseCases.TranscodeVideo
{
    public record TranscodeVideoRequest(
        string ContainerName,
        string BlobName,
        TranscodingInstruction Instruction
    ) : IRequest;
}
