using AutoMapper;
using PostService.Domain;

namespace PostService.Application.UseCases.CreatePost
{
    internal class CreatePostMapper : Profile
    {
        public CreatePostMapper()
        {
            CreateMap<Content, CreatePostResponse_Content>();
            CreateMap<Media, CreatePostResponse_Media>();
            CreateMap<Post, CreatePostResponse>();
        }
    }
}
