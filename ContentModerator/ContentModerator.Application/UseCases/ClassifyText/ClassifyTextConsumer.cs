using MassTransit;

namespace ContentModerator.Application.UseCases.ClassifyText
{
    internal class ClassifyTextConsumer(IModerator moderator) : IConsumer<ClassifyTextRequest>
    {
        private readonly IModerator _moderator = moderator;

        public async Task Consume(ConsumeContext<ClassifyTextRequest> context)
        {
            var moderationResult = await _moderator.ClassifyTextAsync(context.Message.Text, context.CancellationToken);
            await context.RespondAsync(moderationResult);
        }
    }
}
