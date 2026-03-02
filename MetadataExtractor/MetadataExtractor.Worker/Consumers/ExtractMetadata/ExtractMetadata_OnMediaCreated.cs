using MassTransit;
using MediatR;
using Shared.Events.MediaService;

namespace MetadataExtractor.Worker.Consumers.ExtractMetadata
{
    internal class ExtractMetadata_OnMediaCreated(ISender sender, Mapper mapper) : IConsumer<MediaCreatedEvent>
    {
        public Task Consume(ConsumeContext<MediaCreatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
