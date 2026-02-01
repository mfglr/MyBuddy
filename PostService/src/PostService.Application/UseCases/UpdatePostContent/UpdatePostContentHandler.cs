using MassTransit;
using MediatR;
using PostService.Application.Exceptions;
using PostService.Domain;
using PostService.Domain.Exceptions;
using Shared.Events.PostService;

namespace PostService.Application.UseCases.UpdatePostContent
{
    internal class UpdatePostContentHandler(IPostRepository postRepository, IPublishEndpoint publishEndpoint, IIdentityService identityService) : IRequestHandler<UpdatePostContentRequest>
    {
        public async Task Handle(UpdatePostContentRequest request, CancellationToken cancellationToken)
        {
            var content = new Content(request.Content);
            var post =
                await postRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new PostNotFoundException();

            if (identityService.UserId != post.UserId)
                throw new UnauthorizedOperationException();

            post.UpdateContent(content);
            await postRepository.UpdateAsync(post, cancellationToken);

            var @event = new PostContentUpdatedEvent(post.Id, content.Value);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
