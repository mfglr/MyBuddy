using Media.Models;
using MediatR;

namespace ContentModerator.Application.UseCases.ClassifyMedia
{
    public record ClassifyMediaRequest(
        string ContainerName,
        string BlobName,
        MediaType Type,
        ModerationInstruction Instruction
    ) : IRequest;
}
