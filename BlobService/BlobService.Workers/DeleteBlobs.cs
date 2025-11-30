using BlobService.Application.ApplicationServices.DeleteBlob;
using MassTransit;
using MassTransit.Mediator;
using Shared.Events.Media;

namespace BlobService.Workers
{
    internal class DeleteBlobs(IMediator mediator) : IConsumer<MediaDeletedEvent>
    {
        private readonly IMediator _mediator = mediator;

        public Task Consume(ConsumeContext<MediaDeletedEvent> context) =>
            _mediator.Send(
                new DeleteBlobDto(
                    context.Message.ContainerName,
                    context.Message.BlobNames
                ),
                context.CancellationToken
            );
    }
}
