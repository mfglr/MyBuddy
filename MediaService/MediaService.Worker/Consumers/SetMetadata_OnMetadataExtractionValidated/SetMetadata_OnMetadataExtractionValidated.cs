using MassTransit;
using MediatR;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.SetMetadata_OnMetadataExtractionValidated
{
    internal class SetMetadata_OnMetadataExtractionValidated(Mapper mapper, ISender sender) : IConsumer<MetadataExtractionValidatedEvent>
    {
        public Task Consume(ConsumeContext<MetadataExtractionValidatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
