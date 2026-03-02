using PostService.Application.UseCases.SetPostContentModerationResult;
using Shared.Events.PostService;

namespace PostService.Workers.Consumers.SetPostContentModerationResult
{
    internal class Mapper
    {
        public SetPostContentModerationResultRequest Map(PostContentClassifiedEvent @event) =>
            new(
                @event.Id,
                @event.ModerationResult
            );
    }
}
