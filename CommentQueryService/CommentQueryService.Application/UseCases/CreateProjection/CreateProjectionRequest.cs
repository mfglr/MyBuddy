using CommentQueryService.Domain;
using MediatR;

namespace CommentQueryService.Application.UseCases.CreateProjection
{
    public record CreateProjectionRequest(Guid Id, Comment Comment, User User) : IRequest;
}
