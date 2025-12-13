using AutoMapper;
using CommentService.Domain;

namespace CommentService.Application.UseCases.RestoreComment
{
    internal class RestoreCommentMapper : Profile
    {
        public RestoreCommentMapper()
        {
            CreateMap<Content, RestoreCommentResponse_Content>();
            CreateMap<Comment, RestoreCommentResponse>();
        }
    }
}
