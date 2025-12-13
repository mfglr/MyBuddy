using AutoMapper;
using CommentService.Application.Exceptions;
using CommentService.Domain;
using MassTransit;

namespace CommentService.Application.UseCases.UpdateCommentContent
{
    internal class UpdateCommentContentConsumer(ICommentRepository commentRepository, IMapper mapper) : IConsumer<UpdateCommentContentRequest>
    {
        private readonly ICommentRepository _commentRepository = commentRepository;
        private readonly IMapper _mapper = mapper;

        public async Task Consume(ConsumeContext<UpdateCommentContentRequest> context)
        {
            var comment =
                await _commentRepository.GetByIdAsync(context.Message.Id, context.CancellationToken) ??
                throw new CommentNotFoundException();

            if (comment.IsDeleted)
                throw new CommentNotFoundException();

            var content = new Content(context.Message.Content);
            comment.UpdateContent(content);
            await _commentRepository.UpdateAsync(comment, context.CancellationToken);
            await context.RespondAsync(_mapper.Map<Comment, UpdateCommentContentResponse>(comment));
        }
    }
}
