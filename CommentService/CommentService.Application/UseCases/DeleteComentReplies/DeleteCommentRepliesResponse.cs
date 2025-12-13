using Shared.Objects;

namespace CommentService.Application.UseCases.DeleteComentReplies
{
    public record DeleteCommentRepliesResponse_Content(
        string Value,
        ModerationResult ModerationResult
    );
    public record DeleteCommentRepliesResponse_Comment(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        bool IsDeleted,
        int Version,
        Guid UserId,
        Guid PostId,
        Guid? ParentId,
        Guid? RepliedId,
        DeleteCommentRepliesResponse_Content Content
    );

    public record DeleteCommentRepliesResponse(IEnumerable<DeleteCommentRepliesResponse_Comment> Comments);
}
