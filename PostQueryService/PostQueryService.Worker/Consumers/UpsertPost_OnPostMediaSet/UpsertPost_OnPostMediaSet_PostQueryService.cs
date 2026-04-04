using MassTransit;
using MediatR;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.UpsertPost_OnPostMediaSet
{
    internal class UpsertPost_OnPostMediaSet_PostQueryService(
        ISender sender,
        UpsertPost_OnPostMediaSet_Mapper mapper
    ) : IConsumer<PostMediaSetEvent>
    {
        public Task Consume(ConsumeContext<PostMediaSetEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
