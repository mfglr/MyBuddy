using Shared.Events;

namespace PostQueryService.Application.QueryRepositories
{
    public record PostResponse_Content(
        string Value,
        ModerationResult ModerationResult
    );
    public record PostResponse_Media(
        string ContainerName,
        string BlobName,
        MediaType Type,
        Metadata Metadata,
        ModerationResult ModerationResult,
        IEnumerable<Thumbnail> Thumbnails,
        string? TranscodedBlobName
    );
    public record PostResponse(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        PostResponse_Content? Content,
        IEnumerable<PostResponse_Media> Media,
        Guid UserId,
        string? Name,
        string UserName,
        PostResponse_Media? ProfilePhoto
    );
}
