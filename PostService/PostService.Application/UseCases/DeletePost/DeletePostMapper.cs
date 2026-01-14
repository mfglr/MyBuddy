using AutoMapper;
using PostService.Domain;

namespace PostService.Application.UseCases.DeletePost
{
    internal class DeletePostMapper : Profile
    {
        public DeletePostMapper()
        {
            CreateMap<Content, DeletePostResponse_Content>();
            CreateMap<Post, DeletePostResponse>();
        }
    }
}
