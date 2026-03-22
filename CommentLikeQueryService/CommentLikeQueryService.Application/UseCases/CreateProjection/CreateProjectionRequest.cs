using CommentLikeQueryService.Domain;
using MediatR;

namespace CommentLikeQueryService.Application.UseCases.CreateProjection
{
    public record CreateProjectionRequest(ProjectionId Id, CommentLike CommentLike, User User) : IRequest;
}
