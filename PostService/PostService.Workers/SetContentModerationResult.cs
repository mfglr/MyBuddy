using AutoMapper;
using MassTransit;
using PostService.Domain;
using Shared.Events.PostService;

namespace PostService.Workers
{
    internal class SetContentModerationResult(IMapper mapper, IPublishEndpoint publishEndpoint, IPostRepository repository) : IConsumer<PostContentClassifiedEvent>
    {
        private readonly IPostRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        public async Task Consume(ConsumeContext<PostContentClassifiedEvent> context)
        {
            var post = (await _repository.GetByIdAsync(context.Message.Id, context.CancellationToken))!;
            post.SetContentModerationResult(context.Message.ModerationResult);
            await _repository.UpdateAsync(post, context.CancellationToken);

            if (post.IsPreprocessingCompleted)
                await _publishEndpoint
                    .Publish(
                        _mapper.Map<Post, PostPreprocessingCompletedEvent>(post),
                        context.CancellationToken
                    );
        }
    }
}
