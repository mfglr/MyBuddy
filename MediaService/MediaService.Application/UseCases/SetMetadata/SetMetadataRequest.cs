using Media.Models;
using MediatR;

namespace MediaService.Application.UseCases.SetMetadata
{
    public record SetMetadataRequest(
        string ContainerName,
        string BlobName,
        Metadata Metadata
    ) : IRequest;
}
