using MassTransit;
using MediatR;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.UpsertPost_OnPostCreated
{
    internal class UpsertPost_OnPostCreated_PostQueryService(
        ISender sender,
        UpsertPost_OnPostCreated_Mapper  mapper
    ) : IConsumer<PostCreatedEvent>
    {
        public Task Consume(ConsumeContext<PostCreatedEvent> context) =>
            sender.Send(mapper.Map(context.Message),context.CancellationToken);
    }
}
