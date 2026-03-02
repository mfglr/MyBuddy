using MediatR;
using Shared.Events.SharedObjects;

namespace MediaService.Application.UseCases.SetMetadata
{
    public record SetMetadataRequest(
        string ContainerName,
        string BlobName,
        Metadata Metadata
    ) : IRequest;
}
