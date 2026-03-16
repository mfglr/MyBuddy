using CommentService.Domain;
using MassTransit;
using MediatR;

namespace CommentService.Application.UseCases.DeleteComentReplies
{
    internal class DeleteCommentRepliesHandler(
        ICommentRepository commentRepository,
        DeleteCommentRepliesMapper mapper,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<DeleteCommentRepliesRequest>
    {
        public async Task Handle(DeleteCommentRepliesRequest request, CancellationToken cancellationToken)
        {
            var replies = await commentRepository.GetCommentsExceptDeletedByRepliedIdAsync(request.Id, cancellationToken);
            if (replies.Count == 0) return;
            foreach (var reply in replies)
                reply.Delete();
            await commentRepository.UpdateAsync(replies, cancellationToken);

            var events = replies.Select(mapper.Map);
            await publishEndpoint.PublishBatch(events, cancellationToken);
        }
    }
}
