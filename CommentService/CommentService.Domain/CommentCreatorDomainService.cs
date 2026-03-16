using CommentService.Domain.Exceptions;

namespace CommentService.Domain
{
    public class CommentCreatorDomainService(ICommentRepository commentRepository)
    {
        public async Task<Comment> CreateAsync(Guid userId, Guid? postId, Guid? repliedId, Content content,  CancellationToken cancellationToken)
        {
            Guid? parentId = null;
            if (repliedId != null)
            {
                var replied =
                    await commentRepository.GetByIdAsync((Guid)repliedId, cancellationToken) ??
                    throw new CommentNotFoundException();

                if (replied.ParentId != null)
                {
                    if (!await commentRepository.ExistAsync((Guid)replied.ParentId, cancellationToken))
                        throw new CommentNotFoundException();
                    parentId = replied.ParentId;
                }
                else
                    parentId = repliedId;
            }
            return new (userId, postId, parentId, repliedId, content);
        }
    }
}
