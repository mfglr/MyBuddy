using MassTransit;
using MediatR;
using Shared.Events.MediaService;

namespace ThumbnailGenerator.Workers.Consumers.MediaDomain
{
    internal class GenerateThumbnails(ISender sender, Mapper mapper) : IConsumer<GenerateThumbnailMessage>
    {
        public Task Consume(ConsumeContext<GenerateThumbnailMessage> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
