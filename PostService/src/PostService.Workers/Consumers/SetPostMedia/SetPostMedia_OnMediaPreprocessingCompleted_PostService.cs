using MassTransit;
using MediatR;
using PostService.Domain;
using Shared.Events.MediaService;

namespace PostService.Workers.Consumers.SetPostMedia
{
    internal class SetPostMedia_OnMediaPreprocessingCompleted_PostService(
        ISender sender,
        SetPostMedia_OnMediaPreprocessingCompleted_Mapper mapper
    ) : IConsumer<MediaPreprocessingCompletedEvent>
    {
        public Task Consume(ConsumeContext<MediaPreprocessingCompletedEvent> context)
        {
            if (context.Message.ContainerName != Post.MediaContainerName)
                return Task.CompletedTask;
            return sender.Send(mapper.Map(context.Message), context.CancellationToken);
        }
    }
}
