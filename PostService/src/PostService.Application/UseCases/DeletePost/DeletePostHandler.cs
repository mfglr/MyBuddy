using MassTransit;
using MediatR;
using PostService.Application.Exceptions;
using PostService.Domain;
using PostService.Domain.Exceptions;

namespace PostService.Application.UseCases.DeletePost
{
    internal class DeletePostHandler(
        IPostRepository postRepository,
        DeletePostMapper mapper,
        IIdentityService identityService,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<DeletePostRequest>
    {
        public async Task Handle(DeletePostRequest request, CancellationToken cancellationToken)
        {
            var post =
                 await postRepository.GetByIdAsync(request.Id, cancellationToken) ??
                 throw new PostNotFoundException();

            if (!identityService.IsAdminOrOwner(post.UserId))
                throw new UnauthorizedOperationException();

            post.Delete();
            await postRepository.UpdateAsync(post, cancellationToken);

            var @event = mapper.Map(post);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
