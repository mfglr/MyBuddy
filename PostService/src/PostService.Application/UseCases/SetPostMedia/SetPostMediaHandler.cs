using AutoMapper;
using MassTransit;
using MediatR;
using PostService.Domain;
using PostService.Domain.Exceptions;
using Shared.Events.PostService;

namespace PostService.Application.UseCases.SetPostMedia
{
    internal class SetPostMediaHandler(IUnitOfWork unitOfWork, IPostRepository postRepository, IPublishEndpoint publishEndpoint, IMapper mapper) : IRequestHandler<SetPostMediaRequest>
    {
        public async Task Handle(SetPostMediaRequest request, CancellationToken cancellationToken)
        {
            var post = 
                await postRepository.GetByIdAsync(request.Id,cancellationToken) ??
                throw new PostNotFoundException();

            post.SetMedia(
                request.BlobName,
                request.Metadata,
                request.ModerationResult,
                request.Thumbnails,
                request.TranscodedBlobName
            );

            //if (post.IsPreprocessingCompleted())
            //{
            //    var @event = mapper.Map<Post, PostPreprocessingCompletedEvent>(post);
            //    await publishEndpoint.Publish(@event, cancellationToken);
            //}

            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
