using AutoMapper;
using MassTransit;
using MediatR;
using PostService.Domain;
using PostService.Domain.Exceptions;
using Shared.Events.PostService;

namespace PostService.Application.UseCases.SetPostContentModerationResult
{
    internal class SetPostContentModerationResultHandler(IUnitOfWork unitOfWork, IPostRepository repository, IMapper mapper, IPublishEndpoint publishEndpoint) : IRequestHandler<SetPostContentModerationResultRequest>
    {
        public async Task Handle(SetPostContentModerationResultRequest request, CancellationToken cancellationToken)
        {
            var post =
                await repository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new PostNotFoundException();

            post.SetContentModerationResult(request.ModerationResult);

            //if (post.IsPreprocessingCompleted())
            //{
            //    var @event = mapper.Map<Post, PostContentModerationResultSetEvent>(post);
            //    await publishEndpoint.Publish(@event, cancellationToken);
            //}

            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
