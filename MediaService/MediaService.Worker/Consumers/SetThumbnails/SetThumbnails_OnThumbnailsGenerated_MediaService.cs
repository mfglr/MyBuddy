using MassTransit;
using MediatR;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.SetThumbnails
{
    internal class SetThumbnails_OnThumbnailsGenerated_MediaService(ISender sender, SetThumbnails_OnThumbnailsGenerated_Mapper mapper) : IConsumer<ThumbnailsGeneratedEvent>
    {
        public Task Consume(ConsumeContext<ThumbnailsGeneratedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
