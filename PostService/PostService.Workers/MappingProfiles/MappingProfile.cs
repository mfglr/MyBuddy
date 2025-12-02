using AutoMapper;
using PostService.Application.UseCases;
using PostService.Application.UseCases.CreatePost;
using PostService.Domain;
using Shared.Events.PostService;

namespace PostService.Workers.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, CreatePostResponse>();
            CreateMap<Media, CreatePostResponse_Media>();

            CreateMap<Post, PostPreprocessingCompletedEvent>();
            CreateMap<Content, PostPreprocessingCompletedEvent_Content>();
            CreateMap<Media, PostPreprocessingCompletedEvent_Media>();
        }
    }
}
