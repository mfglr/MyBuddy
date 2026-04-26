using MassTransit;
using MediatR;
using Shared.Events.PostService;

namespace PostService.Workers.Consumers.SetPostContentModerationResult
{
    internal class SetPostContentModerationResult_PostContentClassified_PostService(
        ISender sender,
        SetPostContentModerationResult_PostContentClassified_Mapper mapper
    ) : IConsumer<PostContentClassifiedEvent>
    {
        public Task Consume(ConsumeContext<PostContentClassifiedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
