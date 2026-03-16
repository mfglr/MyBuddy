using CommentQueryService.Shared.Model;
using MassTransit;
using Shared.Events.Comment;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertComment_OnCommentCreated
{
    internal class UpsertComment_OnCommentCreated_CommentQueryService(
        ICommentRepository commentRepository,
        UpsertComment_OnCommentCreated_Mapper mapper
    ) : IConsumer<CommentCreatedEvent>
    {
        public async Task Consume(ConsumeContext<CommentCreatedEvent> context)
        {
            try
            {
                await commentRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine("");
            }

        }
    }
}
