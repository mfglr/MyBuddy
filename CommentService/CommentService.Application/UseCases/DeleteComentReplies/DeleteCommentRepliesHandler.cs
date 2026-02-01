using AutoMapper;
using CommentService.Domain;
using MassTransit;
using MediatR;
using Shared.Events.Comment;

namespace CommentService.Application.UseCases.DeleteComentReplies
{
    public class DeleteCommentRepliesHandler(ICommentRepository commentRepository, IUnitOfWork unitOfWork, IMapper mapper, IPublishEndpoint publishEndpoint) : IRequestHandler<DeleteCommentRepliesRequest>
    {
        public async Task Handle(DeleteCommentRepliesRequest request, CancellationToken cancellationToken)
        {
            var replies = await commentRepository.GetByRepliedIdAsync(request.Id, cancellationToken);
            if (replies.Count == 0) return;

            foreach (var reply in replies)
                reply.Delete();
            await unitOfWork.CommitAsync(cancellationToken);

            var events = mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDeletedEvent>>(replies);
            await publishEndpoint.PublishBatch(events, cancellationToken);
        }
    }
}
