using AutoMapper;
using MessageService.Domain.MessageAggregate;

namespace MessageService.Aplication.UseCases.GetUnreceivedMessages
{
    internal class GetUnreceivedMessagesMapper : Profile
    {
        public GetUnreceivedMessagesMapper()
        {
            CreateMap<Message, GetUnreceivedMessagesResponse_Message>()
                .ForCtorParam("media",x => x.MapFrom(x => x.Content.Value));
        }
    }
}
