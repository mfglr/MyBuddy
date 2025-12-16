using AutoMapper;
using CommentService.Application.Exceptions;
using CommentService.Domain;
using MassTransit;

namespace CommentService.Application.UseCases.UpdateCommentContent
{
    public class UpdateCommentContentConsumer(ICommentRepository commentRepository, IMapper mapper, IUnitOfWork unitOfWork) : IConsumer<UpdateCommentContentRequest>
    {
        private readonly ICommentRepository _commentRepository = commentRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task Consume(ConsumeContext<UpdateCommentContentRequest> context)
        {
            var comment =
                await _commentRepository.GetByIdAsync(context.Message.Id, context.CancellationToken) ??
                throw new CommentNotFoundException();
            if (comment.IsDeleted)
                throw new CommentNotFoundException();
            var content = new Content(context.Message.Content);
            comment.UpdateContent(content);
            await _unitOfWork.CommitAsync(context.CancellationToken);
            await context.RespondAsync(_mapper.Map<Comment, UpdateCommentContentResponse>(comment));
        }
    }
}
