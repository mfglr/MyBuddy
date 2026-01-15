using AutoMapper;
using CommentService.Domain;
using MassTransit;
using MediatR;
using Shared.Events.Comment;

namespace CommentService.Application.UseCases.DeletePostComments
{
    public class DeletePostCommentsHandler(ICommentRepository commentRepository, IUnitOfWork unitOfWork, IMapper mapper, IPublishEndpoint publishEndpoint) : IRequestHandler<DeletePostCommentsRequest>
    {
        private readonly ICommentRepository _commentRepository = commentRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        public async Task Handle(DeletePostCommentsRequest request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetByPostIdAsync(request.PostId, cancellationToken);
            foreach (var comment in comments)
                comment.Delete();
            await _unitOfWork.CommitAsync(cancellationToken);

            var events = _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDeletedEvent>>(comments);
            await _publishEndpoint.PublishBatch(events, cancellationToken);
        }
    }
}
