using AutoMapper;

namespace MessageService.Aplication.UseCases.SendMessage
{
    internal class SendMessageMapper : Profile
    {
        public SendMessageMapper()
        {
            CreateMap<SendMessageRequest_Message, MessageResponse>();
        }
    }
}
