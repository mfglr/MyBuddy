using MediatR;
using Shared.Events.SharedObjects;

namespace MediaService.Application.UseCases.CreateMedia
{
    public record CreateMediaRequest_Media(
        string BlobName,
        MediaType Type,
        MediaInstruction Instruction
    );
    public record CreateMediaRequest(
        Guid Id,
        string ContainerName,
        IEnumerable<CreateMediaRequest_Media> Media
    ) : IRequest;
}
