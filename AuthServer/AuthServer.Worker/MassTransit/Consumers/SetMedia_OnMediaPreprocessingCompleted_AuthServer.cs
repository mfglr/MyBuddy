using MassTransit;
using MediatR;
using Shared.Events.MediaService;

namespace AuthServer.Worker.MassTransit.Consumers
{
    internal class SetMedia_OnMediaPreprocessingCompleted_AuthServer(
        ISender sender,
        SetMedia_OnMediaPreprocessingCompleted_Mapper mapper
    ) : IConsumer<MediaPreprocessingCompletedEvent>
    {
        public Task Consume(ConsumeContext<MediaPreprocessingCompletedEvent> context) =>
            context.Message.ContainerName == "UserMedia"
            ? sender.Send(mapper.Map(context.Message), context.CancellationToken)
            : Task.CompletedTask;
    }
}
