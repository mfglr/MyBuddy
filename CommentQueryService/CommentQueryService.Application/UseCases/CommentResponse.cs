using CommentQueryService.Domain;

namespace CommentQueryService.Application.UseCases
{
    public record CommentResponse(
        Guid UserId,
        string UserName,
        string? Name,
        UserMedia? ProfilePhoto,
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        Guid? PostId,
        Guid? ParentId,
        Guid? RepliedId,
        Content Content,
        int LikeCount,
        int ChildCount
    );
}
