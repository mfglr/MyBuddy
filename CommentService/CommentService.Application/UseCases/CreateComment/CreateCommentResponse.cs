using Shared.Objects;

namespace CommentService.Application.UseCases.CreateComment
{
    public record CreateCommentResponse_Content(
        string Value,
        ModerationResult ModerationResult
    );
    public record CreateCommentResponse(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        bool IsDeleted,
        int Version,
        Guid UserId,
        Guid PostId,
        Guid? ParentId,
        Guid? RepliedId,
        CreateCommentResponse_Content Content
    );
}
