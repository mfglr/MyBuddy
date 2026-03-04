//using MassTransit;
//using MediatR;
//using Shared.Events.MediaService;

//namespace PostService.Workers.Consumers.SetPostMedia
//{
//    internal class SetPostMedia(ISender sender, Mapper mapper) : IConsumer<MediaPreprecessingCompletedEvent>
//    {
//        public Task Consume(ConsumeContext<MediaPreprecessingCompletedEvent> context) =>
//            context.Message.ContainerName == "PostMedia"
//                ? sender.Send(mapper.Map(context.Message), context.CancellationToken)
//                : Task.CompletedTask;
//    }
//}
