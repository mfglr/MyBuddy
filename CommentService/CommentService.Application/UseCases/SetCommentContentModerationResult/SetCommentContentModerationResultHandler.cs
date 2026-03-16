using CommentService.Application.Exceptions;
using CommentService.Domain;
using MassTransit;
using MediatR;

namespace CommentService.Application.UseCases.SetCommentContentModerationResult
{
    internal class SetCommentContentModerationResultHandler(
        ICommentRepository commentRepository,
        SetCommentContentModerationResultMapper mapper,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<SetCommentContentModerationResultRequest>
    {
        public async Task Handle(SetCommentContentModerationResultRequest request, CancellationToken cancellationToken)
        {
            var comment =
                await commentRepository.GetCommentByIdAsync(request.Id, cancellationToken) ??
                throw new CommentNotFoundException();
            comment.SetModerationResult(request.ModerationResult);
            await commentRepository.UpdateAsync(comment, cancellationToken);

            var @event = mapper.Map(comment);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
