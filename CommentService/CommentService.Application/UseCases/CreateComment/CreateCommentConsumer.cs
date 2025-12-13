using AutoMapper;
using CommentService.Domain;
using MassTransit;

namespace CommentService.Application.UseCases.CreateComment
{
    internal class CreateCommentConsumer(ICommentRepository commentRepsitory, IMapper mapper, CommentCreatorDomainService commentCreatorDomainService) : IConsumer<CreateCommentRequest>
    {
        private readonly ICommentRepository _commentRepsitory = commentRepsitory;
        private readonly CommentCreatorDomainService _commentCreatorDomainService = commentCreatorDomainService;
        private readonly IMapper _mapper = mapper;

        public async Task Consume(ConsumeContext<CreateCommentRequest> context)
        {
            var content = new Content(context.Message.Content);
            var comment = new Comment(
                context.Message.UserId,
                context.Message.PostId,
                context.Message.ParentId,
                context.Message.RepliedId,
                content
            );
            await _commentCreatorDomainService.CreateAsync(comment,context.CancellationToken);
            await _commentRepsitory.CreateAsync(comment, context.CancellationToken);
            await context.RespondAsync(_mapper.Map<Comment, CreateCommentResponse>(comment));
        }
    }
}
