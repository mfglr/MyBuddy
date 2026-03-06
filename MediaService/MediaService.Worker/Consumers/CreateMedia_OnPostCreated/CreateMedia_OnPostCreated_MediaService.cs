using MassTransit;
using MediatR;
using Shared.Events.PostService;

namespace MediaService.Worker.Consumers.CreateMedia_OnPostCreated
{
    internal class CreateMedia_OnPostCreated_MediaService(ISender sender, CreateMedia_OnPostCreated_Mapper mapper) : IConsumer<PostCreatedEvent>
    {
        public Task Consume(ConsumeContext<PostCreatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
