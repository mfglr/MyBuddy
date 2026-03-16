using CommentService.Application.Exceptions;
using CommentService.Domain;
using MassTransit;
using MediatR;
using Shared.Exceptions;

namespace CommentService.Application.UseCases.UpdateCommentContent
{
    internal class UpdateCommentContentHandler(
        ICommentRepository commentRepository,
        IAuthService authService,
        UpdateCommentContentMapper mapper,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<UpdateCommentContentRequest>
    {
        public async Task Handle(UpdateCommentContentRequest request, CancellationToken cancellationToken)
        {
            var comment =
                await commentRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new CommentNotFoundException();

            if (comment.UserId != authService.UserId)
                throw new ForbiddenOperationException();

            var content = new Content(request.Content);
            comment.UpdateContent(content);
            await commentRepository.UpdateAsync(comment, cancellationToken);

            var events = mapper.Map(comment);
            await publishEndpoint.Publish(events, cancellationToken);
        }
    }
}
