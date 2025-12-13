using AutoMapper;
using CommentService.Application.Exceptions;
using CommentService.Domain;
using MassTransit;

namespace CommentService.Application.UseCases.RestoreComment
{
    internal class RestoreCommentConsumer(ICommentRepository commentRepository, IMapper mapper, IUnitOfWork unitOfWork) : IConsumer<RestoreCommentRequest>
    {
        private readonly ICommentRepository _commentRepository = commentRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task Consume(ConsumeContext<RestoreCommentRequest> context)
        {
            var comment = 
                await _commentRepository.GetByIdAsync(context.Message.Id, context.CancellationToken) ??
                throw new CommentNotFoundException();
            comment.Restore();
            await _unitOfWork.CommitAsync(context.CancellationToken);
            await context.RespondAsync(_mapper.Map<Comment, RestoreCommentResponse>(comment));
        }
    }
}
