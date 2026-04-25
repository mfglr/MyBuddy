using Media.Models;
using MediatR;

namespace CommentQueryService.Application.UseCases.UpsertUser
{
    public record UpsertUserRequest_Media(
        string ContainerName,
        string BlobName,
        MediaType Type,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails,
        IEnumerable<Transcoding> Transcodings
    );

    public record UpsertUserRequest(
        Guid Id,
        int Version,
        string? Name,
        string UserName,
        UpsertUserRequest_Media? Media
    ) : IRequest;
}
