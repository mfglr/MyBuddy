using MassTransit;
using MediatR;
using Shared.Events.CommentLikeService;

namespace CommentLikeQueryService.Worker.MassTransit.Consumers.CreateProjection_OnCommentLikeCreated
{
    internal class CreateProjection_OnCommentCreated_CommentLikeQueryService(
        ISender sender,
        CreateProjection_OnCommentCreated_Mapper mapper
    ) : IConsumer<CommentLikeCreatedEvent>
    {
        public Task Consume(ConsumeContext<CommentLikeCreatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
