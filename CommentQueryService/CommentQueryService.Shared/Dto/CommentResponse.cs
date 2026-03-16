using CommentQueryService.Shared.Model;
using Shared.Events.SharedObjects;

namespace CommentQueryService.Shared.Dto
{
    public record CommentResponse_Content(
        string Value,
        ModerationResult? ModerationResult
    );

    public record CommentResponse(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        DateTime? DeletedAt,
        bool IsDeleted,
        Guid? PostId,
        Guid? ParentId,
        CommentResponse_Content Content,
        int ChildCount,
        int LikeCount,
        Guid UserId,
        string UserName,
        string? Name,
        Media? Media
    );
}
