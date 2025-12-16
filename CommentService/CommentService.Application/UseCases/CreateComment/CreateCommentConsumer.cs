using AutoMapper;
using CommentService.Domain;
using MassTransit;

namespace CommentService.Application.UseCases.CreateComment
{
    public class CreateCommentConsumer(ICommentRepository commentRepsitory, IMapper mapper, CommentCreatorDomainService commentCreatorDomainService, IUnitOfWork unitOfWork, IIdentityService identityService) : IConsumer<CreateCommentRequest>
    {
        private readonly ICommentRepository _commentRepsitory = commentRepsitory;
        private readonly CommentCreatorDomainService _commentCreatorDomainService = commentCreatorDomainService;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IIdentityService _identityService = identityService;

        public async Task Consume(ConsumeContext<CreateCommentRequest> context)
        {
            var content = new Content(context.Message.Content);
            var comment = new Comment(
                _identityService.UserId,
                context.Message.PostId,
                context.Message.ParentId,
                context.Message.RepliedId,
                content
            );
            await _commentCreatorDomainService.CreateAsync(comment, context.CancellationToken);
            await _commentRepsitory.CreateAsync(comment, context.CancellationToken);
            await _unitOfWork.CommitAsync(context.CancellationToken);
            await context.RespondAsync(_mapper.Map<Comment, CreateCommentResponse>(comment));
        }
    }
}
