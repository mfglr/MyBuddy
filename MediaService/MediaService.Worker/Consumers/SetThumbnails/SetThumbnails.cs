using MassTransit;
using MediatR;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.SetThumbnails
{
    internal class SetThumbnails(ISender sender, Mapper mapper) : IConsumer<ThumbnailsGeneratedEvent>
    {
        public Task Consume(ConsumeContext<ThumbnailsGeneratedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
