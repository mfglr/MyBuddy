using AutoMapper;
using CommentService.Domain;
using Shared.Events.Comment;

namespace CommentService.Application.UseCases.RestoreComment
{
    internal class RestoreCommentMapper : Profile
    {
        public RestoreCommentMapper()
        {
            CreateMap<Content, CommentRestoredEvent_Content>();
            CreateMap<Comment, CommentRestoredEvent>();
        }
    }
}
