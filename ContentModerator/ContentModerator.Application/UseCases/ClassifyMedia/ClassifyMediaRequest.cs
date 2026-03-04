using MediatR;
using Shared.Events.SharedObjects;

namespace ContentModerator.Application.UseCases.ClassifyMedia
{
    public record ClassifyMediaRequest(
        Guid Id,
        string ContainerName,
        string BlobName,
        MediaType Type,
        MediaInstruction Instruction
    ) : IRequest;
}
