using CommentService.Domain;
using MassTransit;
using MediatR;

namespace CommentService.Application.UseCases.DeletePostComments
{
    internal class DeletePostCommentsHandler(
        ICommentRepository commentRepository,
        DeletePostCommentsMapper mapper,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<DeletePostCommentsRequest>
    {
        public async Task Handle(DeletePostCommentsRequest request, CancellationToken cancellationToken)
        {
            var comments = await commentRepository.GetByPostIdAsync(request.PostId, cancellationToken);
            if (comments.Count == 0) return;
            foreach (var comment in comments)
                comment.Delete();
            await commentRepository.UpdateAsync(comments, cancellationToken);

            var events = comments.Select(mapper.Map);
            await publishEndpoint.PublishBatch(events, cancellationToken);
        }
    }
}
