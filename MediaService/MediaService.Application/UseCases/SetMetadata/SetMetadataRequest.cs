using MediaService.Domain;
using MediatR;
using Shared.Events.SharedObjects;

namespace MediaService.Application.UseCases.SetMetadata
{
    public record SetMetadataRequest(
        MediaId Id,
        Metadata Metadata
    ) : IRequest;
}
