using Media.Models;
using MediatR;

namespace CommentQueryService.Application.UseCases.UpsertComment
{
    public record UpsertCommentRequest_Content(
        string Value,
        ModerationResult? ModerationResult
    );

    public record UpsertCommentRequest(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        bool IsDeleted,
        int Version,
        Guid UserId,
        Guid PostId,
        Guid? ParentId,
        Guid? RepliedId,
        UpsertCommentRequest_Content Content
    ) : IRequest;
}
