using MassTransit;
using MediatR;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.SetMetadata_OnMetadataExtractionInvalidated
{
    internal class SetMetadata_OnMetadataExtractionInvalidated_MediaService(ISender sender, SetMetadata_OnMetadataExtractionInvalidated_Mapper mapper) : IConsumer<MetadataExtractionInvalidatedEvent>
    {
        public Task Consume(ConsumeContext<MetadataExtractionInvalidatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
