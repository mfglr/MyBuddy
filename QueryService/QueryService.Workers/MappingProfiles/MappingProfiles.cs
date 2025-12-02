using AutoMapper;
using QueryService.Application.UseCases.PostUseCases.CreatePost;
using Shared.Events.PostService;

namespace QueryService.Workers.MappingProfiles
{
    internal class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PostPreprocessingCompletedEvent, CreatePostRequest>();
        }
    }
}
