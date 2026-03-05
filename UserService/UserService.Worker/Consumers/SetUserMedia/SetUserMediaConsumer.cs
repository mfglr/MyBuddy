using MassTransit;
using MediatR;
using Shared.Events.MediaService;
using UserService.Domain;

namespace UserService.Worker.Consumers.SetUserMedia
{
    internal class SetUserMediaConsumer(
        ISender sender,
        SetUserMediaMapper mapper
    ) : IConsumer<MediaPreprecessingCompletedEvent>
    {
        public async Task Consume(ConsumeContext<MediaPreprecessingCompletedEvent> context)
        {
            if(context.Message.ContainerName != User.MediaContainerName)
                return;
            try
            {
                await sender.Send(mapper.Map(context.Message), context.CancellationToken);
            }
            catch (UserNotFoundException)
            {
                return;
            }
            catch (MediaNotFoundException)
            {
                return;
            }
        }
    }
}
