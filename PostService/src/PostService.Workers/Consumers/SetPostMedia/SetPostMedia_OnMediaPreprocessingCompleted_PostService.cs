using MassTransit;
using MediatR;
using PostService.Domain;
using PostService.Domain.Exceptions;
using Shared.Events.MediaService;

namespace PostService.Workers.Consumers.SetPostMedia
{
    internal class SetPostMedia_OnMediaPreprocessingCompleted_PostService(ISender sender, SetPostMedia_OnMediaPreprocessingCompleted_Mapper mapper) : IConsumer<MediaPreprocessingCompletedEvent>
    {
        public async Task Consume(ConsumeContext<MediaPreprocessingCompletedEvent> context)
        {
            if (context.Message.ContainerName != Post.MediaContainerName)
                return;
            try
            {
                await sender.Send(mapper.Map(context.Message), context.CancellationToken);
            }
            catch (PostNotFoundException)
            {
                return;
            }
            catch (PostMediaNotFoundException)
            {
                return;
            }
        }
    }
}
