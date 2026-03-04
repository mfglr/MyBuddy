using MassTransit;
using MediatR;
using PostService.Domain.Exceptions;
using Shared.Events.PostService;

namespace PostService.Workers.Consumers.SetPostContentModerationResult
{
    internal class SetPostContentModerationResult(ISender sender, Mapper mapper) : IConsumer<PostContentClassifiedEvent>
    {
        public static int counter = 0;

        public async Task Consume(ConsumeContext<PostContentClassifiedEvent> context)
        {
            try
            {
                await sender.Send(mapper.Map(context.Message), context.CancellationToken);
            }
            catch (PostNotFoundException)
            {
                return;
            }
            catch (PostContentNotAvailableException)
            {
                return;
            }
        }
    }
}
