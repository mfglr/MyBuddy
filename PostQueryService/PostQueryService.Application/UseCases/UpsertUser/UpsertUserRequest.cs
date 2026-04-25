using Media.Models;
using MediatR;

namespace PostQueryService.Application.UseCases.UpsertUser
{
    public record UpsertUserRequest_Media(
        string ContainerName,
        string BlobName,
        MediaProcessingContext Context
    );

    public record UpsertUserRequest(
        Guid Id,
        int Version,
        string? Name,
        string UserName,
        UpsertUserRequest_Media? Media
    ) : IRequest;
}
