using ContentModerator.Application.UseCases.ClassifyText;
using MassTransit;
using MassTransit.Mediator;
using Shared.Events.Comment;
using Shared.Objects;

namespace ContentModerator.Worker
{
    internal class ClassifyCommentContentOnContentUpdated(IMediator mediator, IPublishEndpoint publishEndpoint) : IConsumer<CommentContentUpdatedEvent>
    {

        private readonly IMediator _mediator = mediator;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        public async Task Consume(ConsumeContext<CommentContentUpdatedEvent> context)
        {
            var client = _mediator.CreateRequestClient<ClassifyTextRequest>();
            var request = new ClassifyTextRequest(context.Message.Content.Value);
            var response = await client.GetResponse<ModerationResult>(request);

            await _publishEndpoint.Publish(
                new CommentContentClassifiedEvent(context.Message.Id, response.Message),
                context.CancellationToken
            );
        }
    }
}
