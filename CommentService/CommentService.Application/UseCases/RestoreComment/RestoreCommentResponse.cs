using Shared.Objects;

namespace CommentService.Application.UseCases.RestoreComment
{
    public record RestoreCommentResponse_Content(
        string Value,
        ModerationResult ModerationResult
    );
    public record RestoreCommentResponse(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        bool IsDeleted,
        int Version,
        Guid UserId,
        Guid PostId,
        Guid? ParentId,
        Guid? RepliedId,
        RestoreCommentResponse_Content Content
    );
}
