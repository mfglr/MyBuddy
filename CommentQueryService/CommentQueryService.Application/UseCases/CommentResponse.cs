using CommentQueryService.Domain.CommentAggregate;
using Media.Models;

namespace CommentQueryService.Application.UseCases
{
    public record CommentResponse_Media(
        string ContainerName,
        string BlobName,
        MediaType Type,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails,
        IEnumerable<Transcoding> Transcodings
    );

    public record CommentResponse(
        Guid UserId,
        string UserName,
        string? Name,
        CommentResponse_Media? UserMedia,
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        Guid? PostId,
        Guid? ParentId,
        Guid? RepliedId,
        CommentContent Content,
        int LikeCount,
        int ChildCount
    );
}
