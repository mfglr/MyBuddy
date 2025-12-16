using AutoMapper;
using CommentService.Domain;
using MassTransit;

namespace CommentService.Application.UseCases.DeletePostComments
{
    public class DeletePostCommentsConsumer(ICommentRepository commentRepository, IUnitOfWork unitOfWork, IMapper mapper) : IConsumer<DeletePostCommentsRequest>
    {
        private readonly ICommentRepository _commentRepository = commentRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task Consume(ConsumeContext<DeletePostCommentsRequest> context)
        {
            var comments = await _commentRepository.GetByPostIdAsync(context.Message.PostId, context.CancellationToken);
            foreach (var comment in comments)
                comment.Delete();
            await _unitOfWork.CommitAsync(context.CancellationToken);
            var response = new DeletePostCommentsResponse(
                _mapper.Map<IEnumerable<Comment>,IEnumerable<DeletePostCommentsResponse_Comment>>(comments)
            );
            await context.RespondAsync(response);
        }
    }
}
