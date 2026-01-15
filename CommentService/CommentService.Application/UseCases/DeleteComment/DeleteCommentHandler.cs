using AutoMapper;
using CommentService.Application.Exceptions;
using CommentService.Domain;
using MassTransit;
using MediatR;
using Shared.Events.Comment;

namespace CommentService.Application.UseCases.DeleteComment
{
    public class DeleteCommentHandler(ICommentRepository commentRepository, IMapper mapper, IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint) : IRequestHandler<DeleteCommentRequest>
    {
        private readonly ICommentRepository _commentRepository = commentRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        public async Task Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
        {
            var comment =
                await _commentRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new CommentNotFoundException();
            if (comment.IsDeleted)
                throw new CommentNotFoundException();
            comment.Delete();
            await _unitOfWork.CommitAsync(cancellationToken);

            var @event = _mapper.Map<Comment, CommentDeletedEvent>(comment);
            await _publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
