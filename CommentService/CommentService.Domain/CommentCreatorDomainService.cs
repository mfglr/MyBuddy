using CommentService.Domain.Exceptions;

namespace CommentService.Domain
{
    public class CommentCreatorDomainService(ICommentRepository commentRepository)
    {
        public async Task<Comment> CreateAsync(Guid userId, Guid? postId, Guid? repliedId, Content content,  CancellationToken cancellationToken)
        {
            if(postId == null && repliedId == null)
                throw new CommentParentException();

            if (postId != null)
                return new(userId, (Guid)postId, null, null, content);

            if (repliedId == null)
                throw new CommentParentException();

            var replied = await commentRepository.GetCommentByIdAsync((Guid)repliedId, cancellationToken);
            if(replied == null || replied.IsDeleted)
                throw new CommentNotFoundException();

            return new (userId, replied.PostId, replied.ParentId ?? repliedId, repliedId, content);
        }
    }
}
