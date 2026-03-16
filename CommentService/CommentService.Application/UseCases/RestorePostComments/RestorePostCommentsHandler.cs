using CommentService.Domain;
using MassTransit;
using MediatR;

namespace CommentService.Application.UseCases.RestorePostComments
{
    internal class RestorePostCommentsHandler(
        ICommentRepository commentRepository,
        RestorePostCommentsMapper mapper,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<RestorePostCommentsRequest>
    {
        public async Task Handle(RestorePostCommentsRequest request, CancellationToken cancellationToken)
        {
            var comments = await commentRepository.GetCommentsByPostIdAsync(request.PostId, cancellationToken);
            if (comments.Count == 0) return;
            foreach (var comment in comments)
                comment.Restore();
            await commentRepository.UpdateAsync(comments, cancellationToken);

            var events = comments.Select(mapper.Map);
            await publishEndpoint.Publish(events, cancellationToken);
        }
    }
}
