using AutoMapper;
using PostQueryService.Domain.PostDomain;

namespace PostQueryService.Application.UseCases.UpsertPost
{
    internal class UpserPostMapper : Profile
    {
        public UpserPostMapper()
        {
            CreateMap<UpsertPostRequest_Content, Content>();
            CreateMap<UpsertPostRequest_Media, PostMedia>();
        }
    }
}
