using MassTransit;
using MassTransit.Mediator;
using ContentModerator.Application;
using Shared.Events.Media;
using Shared.Objects;
using ContentModerator.Application.UseCases.ClassifyVideo;
using ContentModerator.Application.UseCases.ClassifyImage;

namespace ContentModerator.Worker
{
    internal class ClassifyMedia(IMediator mediator, IPublishEndpoint publishEndpoint) : IConsumer<MediaCreatedEvent>
    {
        private readonly IMediator _mediator = mediator;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        public async Task Consume(ConsumeContext<MediaCreatedEvent> context)
        {
            ModerationResult moderationResult;
            if(context.Message.Type == MediaType.Image)
            {
                var client = _mediator.CreateRequestClient<ClassifyImageRequest>();
                var response = await client.GetResponse<ModerationResult>(
                    new ClassifyImageRequest(
                        context.Message.ContainerName,
                        context.Message.BlobName
                    )
                );
                moderationResult = response.Message;
            }
            else
            {
                var client = _mediator.CreateRequestClient<ClassifyVideoRequest>();
                var response = await client.GetResponse<ModerationResult>(
                    new ClassifyVideoRequest(
                        context.Message.ContainerName,
                        context.Message.BlobName
                    )
                );
                moderationResult = response.Message;
            }

            await _publishEndpoint.Publish(
                new MediaClassfiedEvent(
                    context.Message.Id,
                    moderationResult.Hate,
                    moderationResult.SelfHarm,
                    moderationResult.Sexual,
                    moderationResult.Violence
                )
            );
        }
    }
}
