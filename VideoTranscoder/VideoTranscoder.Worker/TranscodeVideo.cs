using MassTransit;
using MassTransit.Mediator;
using Shared.Events.Media;
using Shared.Objects;
using VideoTranscoder.Application.UseCases.TranscodeVideo;

namespace VideoTranscoder.Worker
{
    internal class TranscodeVideo(IMediator mediator, IPublishEndpoint publishEndpoint) : IConsumer<MediaCreatedEvent>
    {
        private readonly IMediator _mediator = mediator;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        public async Task Consume(ConsumeContext<MediaCreatedEvent> context)
        {
            if (context.Message.Type != MediaType.Video) return;

            var client = _mediator.CreateRequestClient<TranscodeVideoRequest>();
            var response = 
                await client.GetResponse<TranscodeVideoResponse>(
                    new (
                        context.Message.Id,
                        context.Message.ContainerName,
                        context.Message.BlobName
                    )
                );
            await _publishEndpoint.Publish(new VideoTranscodedEvent(context.Message.Id, response.Message.BlobName));
        }
    }
}
