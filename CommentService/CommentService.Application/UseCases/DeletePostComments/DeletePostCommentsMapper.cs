using AutoMapper;
using CommentService.Domain;
using Shared.Events.Comment;

namespace CommentService.Application.UseCases.DeletePostComments
{
    internal class DeletePostCommentsMapper : Profile
    {
        public DeletePostCommentsMapper()
        {
            CreateMap<Content, CommentDeletedEvent_Content>();
            CreateMap<Comment, CommentDeletedEvent>();
        }
    }
}
