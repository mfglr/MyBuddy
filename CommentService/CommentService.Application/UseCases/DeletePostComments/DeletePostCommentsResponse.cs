using Shared.Objects;

namespace CommentService.Application.UseCases.DeletePostComments
{

    public record DeletePostCommentsResponse_Content(
        string Value,
        ModerationResult ModerationResult
    );
    public record DeletePostCommentsResponse_Comment(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        bool IsDeleted,
        int Version,
        Guid UserId,
        Guid PostId,
        Guid? ParentId,
        Guid? RepliedId,
        DeletePostCommentsResponse_Content Content
    );
    public record DeletePostCommentsResponse(
        IEnumerable<DeletePostCommentsResponse_Comment> Comments
    );
}
