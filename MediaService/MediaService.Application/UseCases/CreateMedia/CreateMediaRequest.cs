using MediatR;
using Shared.Events.SharedObjects;

namespace MediaService.Application.UseCases.CreateMedia
{
    public record CreateMediaRequest_Media(
        string ContainerName,
        string BlobName,
        MediaType Type,
        MediaInstruction Instruction
    );
    public record CreateMediaRequest(
        Guid Id,
        IEnumerable<CreateMediaRequest_Media> Media
    ) : IRequest;
}
