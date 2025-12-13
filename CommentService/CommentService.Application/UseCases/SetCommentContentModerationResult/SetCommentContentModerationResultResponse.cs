using Shared.Objects;

namespace CommentService.Application.UseCases.SetCommentContentModerationResult
{
    public record SetCommentContentModerationResultResponse_Content(
        string Value,
        ModerationResult ModerationResult
    );
    public record SetCommentContentModerationResultResponse(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        int Version,
        bool IsDeleted,
        Guid UserId,
        Guid PostId,
        Guid? ParentId,
        Guid? RepliedId,
        SetCommentContentModerationResultResponse_Content Content
    );
}
