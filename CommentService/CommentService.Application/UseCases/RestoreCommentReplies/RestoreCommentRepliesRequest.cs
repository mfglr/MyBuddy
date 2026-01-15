using MediatR;

namespace CommentService.Application.UseCases.RestoreCommentReplies
{
    public record RestoreCommentRepliesRequest(Guid Id) : IRequest;
}
