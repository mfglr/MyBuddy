using Shared.Objects;

namespace CommentService.Application.UseCases.DeleteComentReplies
{

    public record DeletCommentRepliesResponse_Content(
        string Value,
        ModerationResult ModerationResult
    );
    public record DeletCommentRepliesResponse_Comment(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        bool IsDeleted,
        int Version,
        Guid UserId,
        Guid PostId,
        Guid? ParentId,
        Guid? RepliedId,
        DeletCommentRepliesResponse_Content Content
    );

    public record DeletCommentRepliesResponse(IEnumerable<DeletCommentRepliesResponse_Comment> Comments);
}
