using MassTransit;
using MassTransit.Mediator;
using MediaService.Application.UseCases.SetMediaMetadata;
using Shared.Events.Media;

namespace MediaService.Workers
{
    internal class SetMediaMetadata(IMediator mediator) : IConsumer<MediaMeatadataExtractedEvent>
    {
        private readonly IMediator _mediator = mediator;

        public Task Consume(ConsumeContext<MediaMeatadataExtractedEvent> context) =>
            _mediator.Send(
                new SetMediaMetadataRequest(
                    context.Message.Id,
                    context.Message.Width,
                    context.Message.Height,
                    context.Message.Duration
                ),
                context.CancellationToken
            );
    }
}
