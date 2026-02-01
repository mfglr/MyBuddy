using AutoMapper;
using PostQueryService.Domain.UserDomain;

namespace PostQueryService.Application.UseCases.UpsertUser
{
    internal class UpsertUserMapper : Profile
    {
        public UpsertUserMapper()
        {
            CreateMap<UpsertUserRequest_Media, UserMedia>();
        }
    }
}
