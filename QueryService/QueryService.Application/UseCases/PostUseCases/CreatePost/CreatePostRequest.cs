using Shared.Objects;

namespace QueryService.Application.UseCases.PostUseCases.CreatePost
{
    public record CreatePostRequest_Content(string Value,ModerationResult ModerationResult);
    public record CreatePostRequest_Media(
        string ContainerName,
        string BlobName,
        MediaType Type,
        string? TranscodedBlobName,
        Metadata Metadata,
        ModerationResult ModerationResult,
        IReadOnlyList<Thumbnail> Thumbnails
    );
    public record CreatePostRequest(
        Guid Id,
        CreatePostRequest_Content? Content,
        IReadOnlyList<CreatePostRequest_Media> Media
    );
}
