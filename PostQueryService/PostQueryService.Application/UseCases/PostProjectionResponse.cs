using Media.Models;

namespace PostQueryService.Application.UseCases
{
    public record PostProjectionResponse_Media(
        string ContainerName,
        string BlobName,
        MediaType Type,
        Metadata Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails,
        IEnumerable<Transcoding> Transcodings
    );

    public record PostProjectionResponse_Content(
        string Value,
        ModerationResult? ModerationResult
    );

    public record PostProjectionResponse(
        string Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        PostProjectionResponse_Content? Content,
        IEnumerable<PostProjectionResponse_Media> Media,
        string UserId,
        string? Name,
        string UserName,
        PostProjectionResponse_Media? UserMedia
    );
}