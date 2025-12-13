using Shared.Objects;

namespace CommentService.Application.UseCases.UpdateCommentContent
{
    public record UpdateCommentContentResponse_Content(
        string Value,
        ModerationResult ModerationResult
    );
    public record UpdateCommentContentResponse(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        bool IsDeleted,
        int Version,
        Guid UserId,
        Guid PostId,
        Guid? ParentId,
        Guid? RepliedId,
        UpdateCommentContentResponse_Content Content
    );
}
