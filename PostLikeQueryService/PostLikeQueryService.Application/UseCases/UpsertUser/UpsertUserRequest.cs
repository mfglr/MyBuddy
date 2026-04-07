using Media.Models;
using MediatR;

namespace PostLikeQueryService.Application.UseCases.UpsertUser
{
    public record UpsertUserRequest_Media(
        string ContainerName,
        string BlobName,
        MediaProcessingContext Context
    );

    public record UpsertUserRequest(
        Guid Id,
        DateTime? DeletedAt,
        int Version,
        string? Name,
        string UserName,
        UpsertUserRequest_Media? Media
    ) : IRequest;
}
