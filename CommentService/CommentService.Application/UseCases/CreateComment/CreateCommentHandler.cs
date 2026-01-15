using AutoMapper;
using CommentService.Domain;
using MassTransit;
using MediatR;
using Shared.Events.Comment;

namespace CommentService.Application.UseCases.CreateComment
{
    public class CreateCommentHandler(ICommentRepository commentRepsitory, IMapper mapper, CommentCreatorDomainService commentCreatorDomainService, IUnitOfWork unitOfWork, IIdentityService identityService, IPublishEndpoint publishEndpoint) : IRequestHandler<CreateCommentRequest, CreateCommentResponse>
    {
        private readonly ICommentRepository _commentRepsitory = commentRepsitory;
        private readonly CommentCreatorDomainService _commentCreatorDomainService = commentCreatorDomainService;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IIdentityService _identityService = identityService;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        public async Task<CreateCommentResponse> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
        {
            var content = new Content(request.Content);
            var comment = new Comment(
                _identityService.UserId,
                request.PostId,
                request.ParentId,
                request.RepliedId,
                content
            );
            await _commentCreatorDomainService.CreateAsync(comment, cancellationToken);
            await _commentRepsitory.CreateAsync(comment, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            var @event = _mapper.Map<Comment, CommentCreatedEvent>(comment);
            await _publishEndpoint.Publish(@event, cancellationToken);

            return new(comment.Id);
        }
    }
}
