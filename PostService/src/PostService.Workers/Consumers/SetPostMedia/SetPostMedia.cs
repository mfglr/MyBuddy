using MassTransit;
using MediatR;
using PostService.Domain;
using PostService.Domain.Exceptions;
using Shared.Events.MediaService;

namespace PostService.Workers.Consumers.SetPostMedia
{
    internal class SetPostMedia(ISender sender, Mapper mapper) : IConsumer<MediaPreprecessingCompletedEvent>
    {
        public async Task Consume(ConsumeContext<MediaPreprecessingCompletedEvent> context)
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
