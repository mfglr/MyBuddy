using CommentQueryService.Domain;
using MediatR;

namespace CommentQueryService.Application.UseCases.UpdateComment
{
    public record UpdateCommentRequest(Guid Id, Comment Comment) : IRequest;
}
