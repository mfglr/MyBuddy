using AutoMapper;
using CommentService.Domain;
using Shared.Events.Comment;

namespace CommentService.Application.UseCases.DeleteComment
{
    internal class DeleteCommentMapper : Profile
    {
        public DeleteCommentMapper()
        {
            CreateMap<Content, CommentDeletedEvent_Content>();
            CreateMap<Comment, CommentDeletedEvent>();
        }
    }
}
