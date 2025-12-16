using AutoMapper;
using CommentService.Domain;
using MassTransit;

namespace CommentService.Application.UseCases.DeleteComentReplies
{
    public class DeleteCommentRepliesConsumer(ICommentRepository commentRepository, IUnitOfWork unitOfWork, IMapper mapper) : IConsumer<DeleteCommentRepliesRequest>
    {
        private readonly ICommentRepository _commentRepository = commentRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task Consume(ConsumeContext<DeleteCommentRepliesRequest> context)
        {
            var replies = await _commentRepository.GetByRepliedIdAsync(context.Message.Id, context.CancellationToken);
            foreach (var reply in replies)
                reply.Delete();
            await _unitOfWork.CommitAsync(context.CancellationToken);

            var response =
                new DeleteCommentRepliesResponse(
                    _mapper.Map<IEnumerable<Comment>,IEnumerable<DeleteCommentRepliesResponse_Comment>>(replies)
                );
            await context.RespondAsync(response);
        }
    }
}
