using MediatR;
using Shared.Events.SharedObjects;

namespace MediaService.Application.UseCases.CreateMedia
{
    public record CreateMediaRequest_Media(
        Guid OwnerId,
        string ContainerName,
        string BlobName,
        MediaType Type,
        MediaInstruction Instruction
    );
    public record CreateMediaRequest(
        IEnumerable<CreateMediaRequest_Media> Media
    ) : IRequest;
}
