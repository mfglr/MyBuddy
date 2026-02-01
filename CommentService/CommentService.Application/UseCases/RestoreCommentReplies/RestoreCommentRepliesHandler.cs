using AutoMapper;
using CommentService.Domain;
using MassTransit;
using MediatR;
using Shared.Events.Comment;

namespace CommentService.Application.UseCases.RestoreCommentReplies
{
    public class RestoreCommentRepliesHandler(ICommentRepository commentRepository, IMapper mapper, IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint) : IRequestHandler<RestoreCommentRepliesRequest>
    {
        private readonly ICommentRepository _commentRepository = commentRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        public async Task Handle(RestoreCommentRepliesRequest request, CancellationToken cancellationToken)
        {
            var replies = await _commentRepository.GetByRepliedIdAsync(request.Id, cancellationToken);
            if (replies.Count == 0) return;

            foreach (var reply in replies)
                reply.Restore();
            await _unitOfWork.CommitAsync(cancellationToken);

            var events = _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentRestoredEvent>>(replies);
            await _publishEndpoint.Publish(events, cancellationToken);
        }
    }
}
