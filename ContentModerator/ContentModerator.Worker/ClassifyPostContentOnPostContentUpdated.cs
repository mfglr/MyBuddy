using ContentModerator.Application.UseCases.ClassifyText;
using MassTransit;
using MassTransit.Mediator;
using Shared.Events.PostService;
using Shared.Objects;

namespace ContentModerator.Worker
{
    internal class ClassifyPostContentOnPostContentUpdated(IMediator mediator, IPublishEndpoint publishEndpoint) : IConsumer<PostContentUpdatedEvent>
    {
        private readonly IMediator _mediator = mediator;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;
        
        public async Task Consume(ConsumeContext<PostContentUpdatedEvent> context)
        {
            if (context.Message.Content == null) return;

            var client = _mediator.CreateRequestClient<ClassifyTextRequest>();
            var request = new ClassifyTextRequest(context.Message.Content.Value);
            var response = await client.GetResponse<ModerationResult>(request);

            await _publishEndpoint.Publish(
                new PostContentClassifiedEvent(context.Message.Id, response.Message),
                context.CancellationToken
            );
        }
    }
}
