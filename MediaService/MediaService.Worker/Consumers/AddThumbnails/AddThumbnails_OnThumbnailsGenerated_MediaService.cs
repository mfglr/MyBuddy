using MassTransit;
using MediatR;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.AddThumbnails
{
    internal class AddThumbnails_OnThumbnailsGenerated_MediaService(
        ISender sender,
        AddThumbnails_OnThumbnailsGenerated_Mapper mapper
    ) : IConsumer<ThumbnailGeneratedEvent>
    {
        public Task Consume(ConsumeContext<ThumbnailGeneratedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
