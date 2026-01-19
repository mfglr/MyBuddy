using ContentModerator.Application.UseCases.ClassifyMedia;
using MassTransit;
using MediatR;
using Shared.Events.MediaService;

namespace ContentModerator.Worker.Consumers
{
    internal class ClassifyMedia_OnMediaMetadataExtracted_ContentModerator(ISender sender) : IConsumer<MediaMetadataExtractedEvent>
    {
        private readonly ISender _sender = sender;

        public Task Consume(ConsumeContext<MediaMetadataExtractedEvent> context)
        {
            if (context.Message.Metadata.Duration > 180) return Task.CompletedTask;

            return _sender
                .Send(
                    new ClassifyMediaRequest(
                        context.Message.Id,
                        context.Message.ContainerName,
                        context.Message.BlobName,
                        context.Message.Type
                ), 
                context.CancellationToken
            );
        }
    }
}
