using AutoMapper;
using CommentService.Domain;
using MassTransit;
using MediatR;
using Shared.Events.Comment;

namespace CommentService.Application.UseCases.DeletePostComments
{
    public class DeletePostCommentsHandler(ICommentRepository commentRepository, IUnitOfWork unitOfWork, IMapper mapper, IPublishEndpoint publishEndpoint) : IRequestHandler<DeletePostCommentsRequest>
    {
        public async Task Handle(DeletePostCommentsRequest request, CancellationToken cancellationToken)
        {
            var comments = await commentRepository.GetByPostIdAsync(request.PostId, cancellationToken);
            if (comments.Count == 0) return;

            foreach (var comment in comments)
                comment.Delete();
            await unitOfWork.CommitAsync(cancellationToken);

            var events = mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDeletedEvent>>(comments);
            await publishEndpoint.PublishBatch(events, cancellationToken);
        }
    }
}
