using MassTransit;
using MediatR;
using Shared.Events.MediaService;

namespace ContentModerator.Worker.Consumers.MediaDomain.ClassifyMedia
{
    internal class ClassifyMedia(ISender sender, Mapper mapper) : IConsumer<MetadataExtractionValidatedEvent>
    {
        public Task Consume(ConsumeContext<MetadataExtractionValidatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
