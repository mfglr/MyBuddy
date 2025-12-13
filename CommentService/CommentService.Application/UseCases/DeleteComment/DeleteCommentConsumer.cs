using AutoMapper;
using CommentService.Application.Exceptions;
using CommentService.Domain;
using MassTransit;

namespace CommentService.Application.UseCases.DeleteComment
{
    internal class DeleteCommentConsumer(ICommentRepository commentRepository, IMapper mapper) : IConsumer<DeleteCommentRequest>
    {
        private readonly ICommentRepository _commentRepository = commentRepository;
        private readonly IMapper _mapper = mapper;

        public async Task Consume(ConsumeContext<DeleteCommentRequest> context)
        {
            var comment =
                await _commentRepository.GetByIdAsync(context.Message.Id, context.CancellationToken) ??
                throw new CommentNotFoundException();

            if (comment.IsDeleted)
                throw new CommentNotFoundException();
            
            comment.Delete();

            await _commentRepository.UpdateAsync(comment, context.CancellationToken);
            await context.RespondAsync(_mapper.Map<Comment, DeleteCommentResponse>(comment));
        }
    }
}
