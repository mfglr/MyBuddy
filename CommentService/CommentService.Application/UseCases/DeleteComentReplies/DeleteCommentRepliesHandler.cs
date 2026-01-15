using AutoMapper;
using CommentService.Domain;
using MassTransit;
using MediatR;
using Shared.Events.Comment;

namespace CommentService.Application.UseCases.DeleteComentReplies
{
    public class DeleteCommentRepliesHandler(ICommentRepository commentRepository, IUnitOfWork unitOfWork, IMapper mapper, IPublishEndpoint publishEndpoint) : IRequestHandler<DeleteCommentRepliesRequest>
    {
        private readonly ICommentRepository _commentRepository = commentRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        public async Task Handle(DeleteCommentRepliesRequest request, CancellationToken cancellationToken)
        {
            var replies = await _commentRepository.GetByRepliedIdAsync(request.Id, cancellationToken);
            foreach (var reply in replies)
                reply.Delete();
            await _unitOfWork.CommitAsync(cancellationToken);

            var events = _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDeletedEvent>>(replies);
            await _publishEndpoint.PublishBatch(events, cancellationToken);
        }
    }
}
