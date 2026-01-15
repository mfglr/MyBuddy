using MediatR;

namespace CommentService.Application.UseCases.UpdateCommentContent
{

    public record UpdateCommentContentRequest(Guid Id, string Content) : IRequest;
}
