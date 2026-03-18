using Media.Models;
using MediatR;

namespace ThumbnailGenerator.Application.UseCases.GenerateThumbnail
{
    public record GenerateThumbnailRequest(
        string ContainerName,
        string BlobName,
        ThumbnailInstruction Instruction
    ) : IRequest;
}
