using MassTransit;
using MediatR;
using Shared.Events.PostService;

namespace PostService.Workers.Consumers.SetPostContentModerationResult
{
    internal class SetPostContentModerationResult(ISender sender, Mapper mapper) : IConsumer<PostContentClassifiedEvent>
    {
        private readonly ISender _sender = sender;

        public Task Consume(ConsumeContext<PostContentClassifiedEvent> context) =>
            _sender.Send(mapper.Map(context.Message),context.CancellationToken);
    }
}
