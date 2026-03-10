using MassTransit;
using MediatR;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.SetMetadata
{
    internal class SetMetadata_OnMetadataExtracted_MediaService(
        ISender sender,
        SetMetadata_OnMetadataExtracted_Mapper mapper
    ) : IConsumer<MediaMetadataExtractedEvent>
    {
        public Task Consume(ConsumeContext<MediaMetadataExtractedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
