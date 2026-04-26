using MassTransit;
using MediatR;
using PostService.Domain;
using PostService.Domain.Exceptions;

namespace PostService.Application.UseCases.DeletePost
{
    internal class DeletePostHandler(
        IPostRepository postRepository,
        DeletePostMapper mapper,
        IBlobService blobService,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<DeletePostRequest>
    {
        public async Task Handle(DeletePostRequest request, CancellationToken cancellationToken)
        {
            var post = 
                await postRepository.GetByIdAsync(request.Id,cancellationToken) ??
                throw new PostNotFoundException();

            post.Delete();

            if (post.ShouldBeDeleted)
            {
                await postRepository.DeleteAsync(post, cancellationToken);
                await blobService.DeleteAsync(Post.MediaContainerName, post.BlobNames, cancellationToken);
            }
            else
                await postRepository.UpdateAsync(post, cancellationToken);

            var @event = mapper.Map(post);
            await publishEndpoint.Publish(@event,cancellationToken);
        }
    }
}
