using MassTransit;
using MediatR;
using PostService.Domain;
using PostService.Domain.Exceptions;

namespace PostService.Application.UseCases.HardDeletePost
{
    internal class HardDeletePostHandler(
        IPostRepository postRepository,
        HardDeletePostMapper mapper,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<HardDeletePostRequest>
    {
        public async Task Handle(HardDeletePostRequest request, CancellationToken cancellationToken)
        {
            var post = 
                await postRepository.GetByIdAsync(request.Id,cancellationToken) ??
                throw new PostNotFoundException();
            
            await postRepository.DeleteAsync(post, cancellationToken);

            var @event = mapper.Map(post);
            await publishEndpoint.Publish(@event,cancellationToken);
        }
    }
}
