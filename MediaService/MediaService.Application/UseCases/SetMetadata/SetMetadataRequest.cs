using MediaService.Domain;
using MediatR;
using Shared.Events.SharedObjects;

namespace MediaService.Application.UseCases.SetMetadata
{
    public record SetMetadataRequest(
        MediaListId Id,
        string BlobName,
        Metadata Metadata
    ) : IRequest;
}
