using AutoMapper;
using PostService.Domain;

namespace PostService.Application.UseCases.SetPostContentModerationResult
{
    internal class SetPostContentModerationResultMapper : Profile
    {
        public SetPostContentModerationResultMapper()
        {
            CreateMap<Content, SetPostContentModerationResultResponse_Content>();
            CreateMap<Post, SetPostContentModerationResultResponse>();
        }
    }
}
