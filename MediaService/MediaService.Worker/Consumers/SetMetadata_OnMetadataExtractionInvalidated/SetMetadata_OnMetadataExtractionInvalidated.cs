using MassTransit;
using MediatR;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.SetMetadata_OnMetadataExtractionInvalidated
{
    internal class SetMetadata_OnMetadataExtractionInvalidated(ISender sender, Mapper mapper) : IConsumer<MetadataExtractionInvalidatedEvent>
    {
        public Task Consume(ConsumeContext<MetadataExtractionInvalidatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
