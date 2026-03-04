using MassTransit;
using MediatR;
using PostService.Domain;
using PostService.Domain.Exceptions;

namespace PostService.Application.UseCases.SetPostContentModerationResult
{
    internal class SetPostContentModerationResultHandler(
        IPostRepository postRepository,
        SetPostContentModerationResultMapper mapper,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<SetPostContentModerationResultRequest>
    {
        public async Task Handle(SetPostContentModerationResultRequest request, CancellationToken cancellationToken)
        {
            var post = 
                await postRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new PostNotFoundException();

            post.SetContentModerationResult(request.ModerationResult);
            await postRepository.UpdateAsync(post, cancellationToken);

            var @event = mapper.Map(post);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
