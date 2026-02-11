using AutoMapper;
using RealtimeService.Domain;

namespace RealtimeService.Application.UseCases.GetConnection
{
    internal class GetConnectionMapper : Profile
    {
        public GetConnectionMapper()
        {
            CreateMap<Connection, GetConnectionResponse>()
                .ForCtorParam("IsOnline", x => x.MapFrom(x => x.ConnectionId != null));
        }
    }
}
