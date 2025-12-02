using AutoMapper;
using PostService.Application.UseCases;
using PostService.Application.UseCases.CreatePost;
using PostService.Domain;

namespace PostService.Api.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, CreatePostResponse>();
            CreateMap<Media, CreatePostResponse_Media>();
        }
    }
}
