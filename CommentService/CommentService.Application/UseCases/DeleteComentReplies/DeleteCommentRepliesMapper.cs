using AutoMapper;
using CommentService.Domain;
using Shared.Events.Comment;

namespace CommentService.Application.UseCases.DeleteComentReplies
{
    internal class DeleteCommentRepliesMapper : Profile
    {
        public DeleteCommentRepliesMapper()
        {
            CreateMap<Content, CommentDeletedEvent_Content>();
            CreateMap<Comment, CommentDeletedEvent>();
        }
    }
}
