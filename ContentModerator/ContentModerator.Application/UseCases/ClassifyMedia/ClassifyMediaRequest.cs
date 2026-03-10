using MediatR;
using Shared.Events.SharedObjects;

namespace ContentModerator.Application.UseCases.ClassifyMedia
{
    public record ClassifyMediaRequest(
        string ContainerName,
        string BlobName,
        MediaType Type,
        ModerationInstruction Instruction
    ) : IRequest;
}
