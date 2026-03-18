using CommentService.Domain.Exceptions;
using Media.Models;

namespace CommentService.Domain
{
    public class Comment
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public bool IsDeleted { get; private set; }
        public int Version { get; private set; }
        public Guid UserId { get; private set; }
        public Guid? PostId { get; private set; }
        public Guid? ParentId { get; private set; }
        public Guid? RepliedId { get; private set; }
        public Content Content { get; private set; }

        internal Comment(Guid userId, Guid? postId, Guid? parentId, Guid? repliedId, Content content)
        {
            if (postId == null && repliedId == null)
                throw new CommentTargetRequiredException();

            Id = Guid.CreateVersion7();
            CreatedAt = DateTime.UtcNow;
            IsDeleted = false;
            Version = 1;
            UserId = userId;
            PostId = postId;
            ParentId = parentId;
            RepliedId = repliedId ?? parentId;
            Content = content ?? throw new ContentRequiredException();
        }

        public void Delete()
        {
            if (IsDeleted)
                throw new CommentNotFoundException();
            IsDeleted = true;
            UpdatedAt = DeletedAt = DateTime.UtcNow;
            Version++;
        }

        public void Restore()
        {
            if(!IsDeleted)
                throw new CommentAlreadyAvailableException();
            IsDeleted = false;
            DeletedAt = null;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }

        public void SetModerationResult(ModerationResult result)
        {
            Content.ModerationResult = result;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }

        public void UpdateContent(Content content)
        {
            if (IsDeleted)
                throw new CommentNotFoundException();
            Content = content;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
    }
}
