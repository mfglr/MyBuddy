using AutoMapper;
using CommentService.Domain;
using MassTransit;

namespace CommentService.Application.UseCases.RestoreCommentReplies
{
    internal class RestoreCommentRepliesConsumer(ICommentRepository commentRepository, IMapper mapper, IUnitOfWork unitOfWork) : IConsumer<RestoreCommentRepliesRequest>
    {
        private readonly ICommentRepository _commentRepository = commentRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task Consume(ConsumeContext<RestoreCommentRepliesRequest> context)
        {
            var replies = await _commentRepository.GetByRepliedIdAsync(context.Message.Id, context.CancellationToken);
            foreach (var reply in replies)
                reply.Restore();
            await _unitOfWork.CommitAsync(context.CancellationToken);
            var response = new RestoreCommentRepliesResponse(
                _mapper.Map<IEnumerable<Comment>, IEnumerable<RestoreCommentRepliesResponse_Comment>>(replies)
            );
            await context.RespondAsync(response);
        }
    }
}
