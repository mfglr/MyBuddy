using MassTransit;
using MassTransit.Mediator;
using MetadataExtractor.Application;
using MetadataExtractor.Application.UseCases.ExtractMediaDimention;
using Shared.Events.Media;

namespace MetadataExtractor.Worker
{
    internal class ExtractMediaMetadata(IMediator mediator, IPublishEndpoint publishEndpoint) : IConsumer<MediaCreatedEvent>
    {
        private readonly IMediator _mediator = mediator;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        public async Task Consume(ConsumeContext<MediaCreatedEvent> context)
        {
            var client = _mediator.CreateRequestClient<ExtractMediaMetadataRequest>();
            var response = await client.GetResponse<Metadata>(new ExtractMediaMetadataRequest(
                context.Message.ContainerName,
                context.Message.BlobName
            ));

            await _publishEndpoint.Publish(
                new MediaMeatadataExtractedEvent(
                    context.Message.Id,
                    response.Message.Width,
                    response.Message.Height,
                    response.Message.Duration
                ),
                context.CancellationToken
            );
        }
    }
}
