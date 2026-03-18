using Media.Models;
using MediatR;

namespace VideoTranscoder.Application.UseCases.TranscodeVideo
{
    public record TranscodeVideoRequest(
        string ContainerName,
        string BlobName,
        TranscodingInstruction Instruction
    ) : IRequest;
}
