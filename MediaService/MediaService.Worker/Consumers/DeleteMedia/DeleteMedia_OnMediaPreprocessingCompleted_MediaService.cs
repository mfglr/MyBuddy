using MassTransit;
using MediatR;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.DeleteMedia
{
    internal class DeleteMedia_OnMediaPreprocessingCompleted_MediaService(ISender sender, DeleteMedia_OnMediaPreprocessingCompleted_Mapper mapper) : IConsumer<MediaPreprocessingCompletedEvent>
    {
        public Task Consume(ConsumeContext<MediaPreprocessingCompletedEvent> context) =>
            sender.Send(mapper.Map(context.Message),context.CancellationToken);
    }
}
