using AutoMapper;
using CommentService.Domain;

namespace CommentService.Application.UseCases.UpdateCommentContent
{
    internal class UpdateCommentContentMapper : Profile
    {
        public UpdateCommentContentMapper()
        {
            CreateMap<Content, UpdateCommentContentResponse_Content>();
            CreateMap<Comment, UpdateCommentContentResponse>();
        }
    }
}
