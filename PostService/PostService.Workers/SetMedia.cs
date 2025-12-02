using AutoMapper;
using MassTransit;
using PostService.Domain;
using Shared.Events.Media;
using Shared.Events.PostService;

namespace PostService.Workers
{
    internal class SetMedia(IMapper mapper, IPublishEndpoint publishEndpoint, IPostRepository postRepository) : IConsumer<MediaPreprocessingCompletedEvent>
    {
        private readonly IPostRepository _postRepository = postRepository;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;
        private readonly IMapper _mapper = mapper;

        public async Task Consume(ConsumeContext<MediaPreprocessingCompletedEvent> context)
        {
            var post = (await _postRepository.GetByIdAsync(context.Message.Id, context.CancellationToken))!;
            post.SetMedia(
                context.Message.BlobName,
                context.Message.TranscodedBlobName,
                context.Message.Metadata,
                context.Message.ModerationResult,
                context.Message.Thumbnails
            );
            await _postRepository.UpdateAsync(post, context.CancellationToken);

            if (post.IsPreprocessingCompleted)
                await _publishEndpoint
                    .Publish(
                        _mapper.Map<Post, PostPreprocessingCompletedEvent>(post),
                        context.CancellationToken
                    );
        }
    }
}
