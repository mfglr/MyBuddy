using MassTransit;
using MassTransit.Mediator;
using MediaService.Application.UseCases.SetMediaModerationResult;
using Shared.Events.Media;

namespace MediaService.Workers
{
    internal class SetMediaModerationResult(IMediator mediator) : IConsumer<MediaClassfiedEvent>
    {
        private readonly IMediator _mediator = mediator;

        public Task Consume(ConsumeContext<MediaClassfiedEvent> context) =>
            _mediator.Send(
                new SetMediaModerationResultRequest(
                    context.Message.Id,
                    context.Message.Hate,
                    context.Message.SelfHarm,
                    context.Message.Sexual,
                    context.Message.Violence
                )
            );
    }
}
