using AutoMapper;
using CommentService.Domain;

namespace CommentService.Application.UseCases.DeletePostComments
{
    internal class DeletePostCommentsMapper : Profile
    {
        public DeletePostCommentsMapper()
        {
            CreateMap<Content, DeletePostCommentsResponse_Content>();
            CreateMap<Comment, DeletePostCommentsResponse_Comment>();
        }
    }
}
