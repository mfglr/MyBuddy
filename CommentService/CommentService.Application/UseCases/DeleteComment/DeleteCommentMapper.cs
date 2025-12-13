using AutoMapper;
using CommentService.Domain;

namespace CommentService.Application.UseCases.DeleteComment
{
    internal class DeleteCommentMapper : Profile
    {
        public DeleteCommentMapper()
        {
            CreateMap<Content, DeleteCommentResponse_Content>();
            CreateMap<Comment, DeleteCommentResponse>();
        }
    }
}
