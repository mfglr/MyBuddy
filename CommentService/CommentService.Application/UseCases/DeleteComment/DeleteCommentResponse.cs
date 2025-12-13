using Shared.Objects;

namespace CommentService.Application.UseCases.DeleteComment
{
    public record DeleteCommentResponse_Content(
        string Value,
        ModerationResult ModerationResult
    );
    public record DeleteCommentResponse(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        bool IsDeleted,
        int Version,
        Guid UserId,
        Guid PostId,
        Guid? ParentId,
        Guid? RepliedId,
        DeleteCommentResponse_Content Content
    );
}
