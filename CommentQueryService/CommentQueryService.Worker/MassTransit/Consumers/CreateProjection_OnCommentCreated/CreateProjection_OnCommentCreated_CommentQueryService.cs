using MassTransit;
using MediatR;
using Shared.Events.Comment;

namespace CommentQueryService.Worker.MassTransit.Consumers.CreateProjection_OnCommentCreated
{
    internal class CreateProjection_OnCommentCreated_CommentQueryService(
        ISender sender,
        CreateProjection_OnCommentCreated_Mapper mapper
    ) : IConsumer<CommentCreatedEvent>
    {
        public Task Consume(ConsumeContext<CommentCreatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
