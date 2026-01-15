using MediatR;

namespace CommentService.Application.UseCases.DeletePostComments
{
    public record DeletePostCommentsRequest(Guid PostId) : IRequest;
}
