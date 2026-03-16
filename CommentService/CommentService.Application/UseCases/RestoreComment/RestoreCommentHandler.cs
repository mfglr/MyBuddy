using CommentService.Application.Exceptions;
using CommentService.Domain;
using MassTransit;
using MediatR;

namespace CommentService.Application.UseCases.RestoreComment
{
    internal class RestoreCommentHandler(
        ICommentRepository commentRepository,
        RestoreCommentMapper mapper,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<RestoreCommentRequest>
    {
        public async Task Handle(RestoreCommentRequest request, CancellationToken cancellationToken)
        {
            var comment =
                await commentRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new CommentNotFoundException();
            comment.Restore();
            await commentRepository.UpdateAsync(comment, cancellationToken);

            var @event = mapper.Map(comment);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
