using AutoMapper;
using MessageService.Domain;

namespace MessageService.Application.UseCases.GetMessage
{
    internal class GetMessageMapper : Profile
    {
        public GetMessageMapper()
        {
            CreateMap<Message, GetMessageResponse>()
                .ForCtorParam("Content", x => x.MapFrom(x => x.Content.Value));
        }
    }
}
