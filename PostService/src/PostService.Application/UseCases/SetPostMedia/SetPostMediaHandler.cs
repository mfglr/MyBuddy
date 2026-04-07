using MassTransit;
using MediatR;
using PostService.Domain;
using PostService.Domain.Exceptions;

namespace PostService.Application.UseCases.SetPostMedia
{
    internal class SetPostMediaHandler(
        IPostRepository postRepository,
        IPublishEndpoint publishEndpoint,
        SetPostMediaMapper mapper
    ) : IRequestHandler<SetPostMediaRequest>
    {
        public async Task Handle(SetPostMediaRequest request, CancellationToken cancellationToken)
        {
            var post =
                await postRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new PostNotFoundException();

            post.SetMedia(request.BlobName, request.Context);
            await postRepository.UpdateAsync(post, cancellationToken);

            var @event = mapper.Map(post);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
