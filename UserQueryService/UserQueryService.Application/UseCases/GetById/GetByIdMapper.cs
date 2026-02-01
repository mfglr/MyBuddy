using AutoMapper;
using UserQueryService.Domain;

namespace UserQueryService.Application.UseCases.GetById
{
    internal class GetByIdMapper : Profile
    {
        public GetByIdMapper()
        {
            CreateMap<Metadata, Shared.Events.Metadata>();
            CreateMap<ModerationResult, Shared.Events.ModerationResult>();
            CreateMap<Thumbnail, Shared.Events.Thumbnail>();
            CreateMap<Media, GetByIdResponse_Media>();
            CreateMap<User, GetByIdResponse>();
        }
    }
}
