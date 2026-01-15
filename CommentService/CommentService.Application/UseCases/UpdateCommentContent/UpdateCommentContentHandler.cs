using AutoMapper;
using CommentService.Application.Exceptions;
using CommentService.Domain;
using MassTransit;
using MediatR;
using Shared.Events.Comment;

namespace CommentService.Application.UseCases.UpdateCommentContent
{
    public class UpdateCommentContentHandler(ICommentRepository commentRepository, IMapper mapper, IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint) : IRequestHandler<UpdateCommentContentRequest>
    {
        private readonly ICommentRepository _commentRepository = commentRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        public async Task Handle(UpdateCommentContentRequest request, CancellationToken cancellationToken)
        {
            var comment =
                await _commentRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new CommentNotFoundException();

            if (comment.IsDeleted)
                throw new CommentNotFoundException();
            
            var content = new Content(request.Content);
            comment.UpdateContent(content);
            await _unitOfWork.CommitAsync(cancellationToken);

            var events = _mapper.Map<Comment, CommentContentUpdatedEvent>(comment);
            await _publishEndpoint.Publish(events, cancellationToken);
        }
    }
}
