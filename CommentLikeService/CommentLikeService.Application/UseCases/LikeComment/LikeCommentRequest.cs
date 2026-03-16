using MediatR;

namespace CommentLikeService.Application.UseCases.LikeComment
{
    public record LikeCommentRequest(Guid CommentId) : IRequest;
}
