using MassTransit;
using MediatR;
using Shared.Events.MediaService;

namespace MetadataExtractor.Worker.Consumers.ExtractMetadata
{
    internal class ExtractMetadata_OnMediaCreated(ISender sender, Mapper mapper) : IConsumer<ExtractMediaMetadataMessage>
    {
        public Task Consume(ConsumeContext<ExtractMediaMetadataMessage> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
