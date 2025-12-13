using CommentService.Domain;
using MassTransit;

namespace CommentService.Application.UseCases.DeleteComentReplies
{
    internal class DeleteCommentRepliesConsumer(ICommentRepository commentRepository) : IConsumer<DeleteCommentRepliesRequest>
    {
        private readonly ICommentRepository _commentRepository = commentRepository;

        public async Task Consume(ConsumeContext<DeleteCommentRepliesRequest> context)
        {
            var replies = await _commentRepository.GetByRepliedIdAsync(context.Message.RepliedId,context.CancellationToken);

            foreach (var reply in replies)
                reply.Delete();
        }
    }
}
