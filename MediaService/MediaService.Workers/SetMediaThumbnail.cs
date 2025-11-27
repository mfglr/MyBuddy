using MassTransit;
using MassTransit.Mediator;
using MediaService.Application.UseCases.SetMediaThumbnail;
using Shared.Events.Media;

namespace MediaService.Workers
{
    internal class SetMediaThumbnail(IMediator mediator) : IConsumer<MediaThumbnailGeneratedEvent>
    {
        private readonly IMediator _mediator = mediator;

        public Task Consume(ConsumeContext<MediaThumbnailGeneratedEvent> context) =>
            _mediator.Send(new SetMediaThumbnailRequest(
                context.Message.Id,
                context.Message.BlobName,
                context.Message.Resulation,
                context.Message.IsSquare
            ),context.CancellationToken);
    }
}
