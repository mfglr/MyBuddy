using MediatR;

namespace CommentLikeQueryService.Application.UseCases.DeleteCommentLike
{
    public record DeleteCommentLikeRequest(Guid CommentId, Guid SequenceId, Guid UserId) : IRequest;
}
