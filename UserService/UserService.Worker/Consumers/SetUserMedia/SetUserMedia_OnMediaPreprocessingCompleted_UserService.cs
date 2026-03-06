using MassTransit;
using MediatR;
using Shared.Events.MediaService;
using UserService.Domain;

namespace UserService.Worker.Consumers.SetUserMedia
{
    internal class SetUserMedia_OnMediaPreprocessingCompleted_UserService(
        ISender sender,
        SetUserMedia_OnMediaPreprocessingCompleted_Mapper mapper
    ) : IConsumer<MediaPreprocessingCompletedEvent>
    {
        public async Task Consume(ConsumeContext<MediaPreprocessingCompletedEvent> context)
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
