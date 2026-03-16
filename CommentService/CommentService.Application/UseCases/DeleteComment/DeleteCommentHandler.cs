using CommentService.Application.Exceptions;
using CommentService.Domain;
using MassTransit;
using MediatR;
using Shared.Exceptions;

namespace CommentService.Application.UseCases.DeleteComment
{
    internal class DeleteCommentHandler(
        ICommentRepository commentRepository,
        IAuthService authService,
        DeleteCommentMapper mapper,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<DeleteCommentRequest>
    {
        public async Task Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
        {
            var comment =
                await commentRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new CommentNotFoundException();

            if (comment.UserId != authService.UserId)
                throw new ForbiddenOperationException();

            comment.Delete();
            await commentRepository.UpdateAsync(comment, cancellationToken);

            var @event = mapper.Map(comment);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
