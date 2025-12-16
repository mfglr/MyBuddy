using AutoMapper;
using CommentService.Application.Exceptions;
using CommentService.Domain;
using MassTransit;

namespace CommentService.Application.UseCases.SetCommentContentModerationResult
{
    public class SetCommentContentModerationResultConsumer(ICommentRepository commentRepository, IMapper mapper, IUnitOfWork unitOfWork) : IConsumer<SetCommentContentModerationResultRequest>
    {
        private readonly ICommentRepository _commentRepository = commentRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Consume(ConsumeContext<SetCommentContentModerationResultRequest> context)
        {
            var comment =
                await _commentRepository.GetByIdAsync(context.Message.Id, context.CancellationToken) ??
                throw new CommentNotFoundException();
            comment.SetModerationResult(context.Message.ModerationResult);
            await _unitOfWork.CommitAsync(context.CancellationToken);
            await context.RespondAsync(_mapper.Map<Comment, SetCommentContentModerationResultResponse>(comment));
        }
    }
}
