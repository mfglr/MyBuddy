using AutoMapper;
using CommentService.Domain;
using Shared.Events.Comment;

namespace CommentService.Application.UseCases.UpdateCommentContent
{
    internal class UpdateCommentContentMapper : Profile
    {
        public UpdateCommentContentMapper()
        {
            CreateMap<Content, CommentContentUpdatedEvent_Content>();
            CreateMap<Comment, CommentContentUpdatedEvent>();
        }
    }
}
