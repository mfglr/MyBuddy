using MassTransit;
using MassTransit.Mediator;
using MediaService.Application.UseCases.SetMediaTranscodedBlobName;
using Shared.Events.Media;

namespace MediaService.Workers
{
    internal class SetMediaTranscodedBlobName(IMediator mediator) : IConsumer<VideoTranscodedEvent>
    {
        private readonly IMediator _mediator = mediator;

        public Task Consume(ConsumeContext<VideoTranscodedEvent> context) =>
            _mediator.Send(new SetMediaTranscodedBlobNameRequest(
                context.Message.Id,
                context.Message.BlobName
            ),context.CancellationToken);
    }
}
