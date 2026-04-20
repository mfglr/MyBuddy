using CommentService.Domain;
using MassTransit;
using MediatR;

namespace CommentService.Application.UseCases.CreateComment
{
    internal class CreateCommentHandler(
        ICommentRepository commentRepsitory,
        CreateCommentMapper mapper,
        CommentCreatorDomainService commentCreatorDomainService,
        IAuthService authService,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<CreateCommentRequest, CreateCommentResponse>
    {
        public async Task<CreateCommentResponse> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
        {
            var content = new Content(request.Content);
            var comment = await commentCreatorDomainService.CreateAsync(
                authService.UserId,
                request.PostId,
                request.RepliedId,
                content,
                cancellationToken
            );
            await commentRepsitory.CreateAsync(comment, cancellationToken);

            var @event = mapper.Map(comment);
            await publishEndpoint.Publish(@event, cancellationToken);

            return new(comment.Id);
        }
    }
}
