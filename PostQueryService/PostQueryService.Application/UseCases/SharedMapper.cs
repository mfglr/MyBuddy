using AutoMapper;
using PostQueryService.Domain;

namespace PostQueryService.Application.UseCases
{
    internal class SharedMapper : Profile
    {
        public SharedMapper()
        {
            CreateMap<Shared.Events.Metadata, Metadata>().ReverseMap();
            CreateMap<Shared.Events.ModerationResult, ModerationResult>().ReverseMap();
            CreateMap<Shared.Events.Thumbnail, Thumbnail>().ReverseMap();
        }
    }
}
