using CommentLikeQueryService.Domain.CommentLikeAggregate;
using MediatR;

namespace CommentLikeQueryService.Application.UseCases.DeleteCommentLike
{
    internal class DeleteCommentLikeHandler(ICommentLikeRepository repository) : IRequestHandler<DeleteCommentLikeRequest>
    {
        public async Task Handle(DeleteCommentLikeRequest request, CancellationToken cancellationToken)
        {
            var id = new CommentLikeId(request.CommentId,request.SequenceId,request.UserId);
            var commentLike = 
                await repository.GetByIdAsync(id, cancellationToken) ??
                throw new CommentLikeNotFound();
            await repository.DeleteAsync(commentLike, cancellationToken);
        }
    }
}
