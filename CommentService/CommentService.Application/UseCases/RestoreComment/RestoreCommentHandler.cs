using AutoMapper;
using CommentService.Application.Exceptions;
using CommentService.Domain;
using MassTransit;
using MediatR;
using Shared.Events.Comment;

namespace CommentService.Application.UseCases.RestoreComment
{
    public class RestoreCommentHandler(ICommentRepository commentRepository, IMapper mapper, IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint) : IRequestHandler<RestoreCommentRequest>
    {
        private readonly ICommentRepository _commentRepository = commentRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        public async Task Handle(RestoreCommentRequest request, CancellationToken cancellationToken)
        {
            var comment =
                await _commentRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new CommentNotFoundException();
            comment.Restore();
            await _unitOfWork.CommitAsync(cancellationToken);

            var @event = _mapper.Map<Comment, CommentRestoredEvent>(comment);
            await _publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
