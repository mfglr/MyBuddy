using MediatR;
using Shared.Events;

namespace PostQueryService.Application.UseCases.UpsertPost
{
    public record UpsertPostRequest_Content(
        string Value,
        ModerationResult ModerationResult
    );
    public record UpsertPostRequest_Media(
        string ContainerName,
        string BlobName,
        MediaType Type,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails,
        string? TranscodedBlobName
    );
    public record UpsertPostRequest(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        int Version,
        bool IsDeleted,
        Guid UserId,
        UpsertPostRequest_Content Content,
        IEnumerable<UpsertPostRequest_Media> Media
    ) : IRequest;
}
