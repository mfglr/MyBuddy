using CommentLikeQueryService.Domain;

namespace CommentLikeQueryService.Application
{
    public record CommentLikeResponse(
        Guid CommentId,
        Guid SequenceId,
        DateTime CreatedAt,
        Guid UserId,
        string UserName,
        string? Name,
        UserMedia? Media
    );
}
