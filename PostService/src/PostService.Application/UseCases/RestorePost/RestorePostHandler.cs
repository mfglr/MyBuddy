using MassTransit;
using MediatR;
using PostService.Domain;
using PostService.Domain.Exceptions;
using Shared.Events.PostService;

namespace PostService.Application.UseCases.RestorePost
{
    internal class RestorePostHandler(
        IPostRepository postRepository,
        RestorePostMapper mapper,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<RestorePostRequest>
    {
        public async Task Handle(RestorePostRequest request, CancellationToken cancellationToken)
        {
            var post =
               await postRepository.GetByIdAsync(request.Id, cancellationToken) ??
               throw new PostNotFoundException();
            
            post.Restore();
            await postRepository.UpdateAsync(post, cancellationToken);

            var @event = mapper.Map(post);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
