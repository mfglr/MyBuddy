using CommentService.Domain;
using MassTransit;
using MediatR;

namespace CommentService.Application.UseCases.RestoreCommentReplies
{
    internal class RestoreCommentRepliesHandler(
        ICommentRepository commentRepository,
        RestoreCommentRepliesMapper mapper,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<RestoreCommentRepliesRequest>
    {
        public async Task Handle(RestoreCommentRepliesRequest request, CancellationToken cancellationToken)
        {
            var replies = await commentRepository.GetCommentsByRepliedIdAsync(request.Id, cancellationToken);
            if (replies.Count == 0) return;
            foreach (var reply in replies)
                reply.Restore();
            await commentRepository.UpdateAsync(replies, cancellationToken);

            var events = replies.Select(mapper.Map);
            await publishEndpoint.Publish(events, cancellationToken);
        }
    }
}
