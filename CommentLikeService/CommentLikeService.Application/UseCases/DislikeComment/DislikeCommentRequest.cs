using MediatR;

namespace CommentLikeService.Application.UseCases.DislikeComment
{
    public record DislikeCommentRequest(Guid CommentId) : IRequest;
}
