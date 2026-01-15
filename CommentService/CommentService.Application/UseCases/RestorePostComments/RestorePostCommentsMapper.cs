using AutoMapper;
using CommentService.Domain;
using Shared.Events.Comment;

namespace CommentService.Application.UseCases.RestorePostComments
{
    internal class RestorePostCommentsMapper : Profile
    {
        public RestorePostCommentsMapper()
        {
            CreateMap<Content, CommentRestoredEvent_Content>();
            CreateMap<Comment, CommentRestoredEvent>();
        }
    }
}
