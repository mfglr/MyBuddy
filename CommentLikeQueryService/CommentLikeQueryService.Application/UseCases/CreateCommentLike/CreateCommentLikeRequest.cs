using MediatR;

namespace CommentLikeQueryService.Application.UseCases.CreateCommentLike
{
    public record CreateCommentLikeRequest(
        Guid CommentId,
        Guid SequenceId,
        Guid UserId,
        DateTime CreatedAt
    ) : IRequest;
}
