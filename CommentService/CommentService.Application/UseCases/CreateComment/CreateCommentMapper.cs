using AutoMapper;
using CommentService.Domain;
using Shared.Events.Comment;

namespace CommentService.Application.UseCases.CreateComment
{
    internal class CreateCommentMapper : Profile
    {
        public CreateCommentMapper()
        {
            CreateMap<Content, CommentCreatedEvent_Content>();
            CreateMap<Comment, CommentCreatedEvent>();
        }
    }
}
