using Media.Models;
using MediatR;

namespace PostQueryService.Application.UseCases.UpdatePostUser
{
    public record UpdatePostUserRequest_Media(
        string ContainerName,
        string BlobName,
        MediaProcessingContext Context
    );

    public record UpdatePostUserRequest(
        Guid Id,
        int Version,
        string UserName,
        string? Name,
        UpdatePostUserRequest_Media? Media
    ) : IRequest;
}
