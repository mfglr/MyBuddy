using CommentService.Domain.Exceptions;

namespace CommentService.Domain
{
    public class CommentCreatorDomainService(ICommentRepository commentRepository)
    {
        private readonly ICommentRepository _commentRepository = commentRepository;

        public async Task CreateAsync(Comment comment,  CancellationToken cancellationToken)
        {
            if (
                    comment.ParentId != null &&
                    !await _commentRepository.ExistAsync((Guid)comment.ParentId, cancellationToken)
            )
                throw new CommentNotFoundException();

            if (
                comment.RepliedId != null &&
                !await _commentRepository.ExistAsync((Guid)comment.RepliedId, cancellationToken)
            )
                throw new CommentNotFoundException();

            comment.Create();
        }
    }
}
