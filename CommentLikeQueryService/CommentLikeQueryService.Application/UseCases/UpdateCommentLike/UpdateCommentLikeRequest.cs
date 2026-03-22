using CommentLikeQueryService.Domain;
using MediatR;

namespace CommentLikeQueryService.Application.UseCases.UpdateCommentLike
{
    public record UpdateCommentLikeRequest(ProjectionId Id, CommentLike CommentLike) : IRequest;
}
