using AutoMapper;
using PostService.Domain;

namespace PostService.Application.UseCases.CreatePost
{
    internal class CreatePostMapper : Profile
    {
        public CreatePostMapper()
        {
            CreateMap<Content, CreatePostResponse_Content>();
            CreateMap<Post, CreatePostResponse>();
        }
    }
}
