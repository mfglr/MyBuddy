using AutoMapper;
using RealtimeService.Application.UseCases.SendMessage;
using Shared.Events.MessageService;

namespace RealtimeService.Api.Consumers
{
    public class SendMessage_OnMessageCreated_Mapper : Profile
    {
        public SendMessage_OnMessageCreated_Mapper()
        {
            CreateMap<MessageCreatedEvent_Message, SendMessageRequest_Message>();
            CreateMap<MessageCreatedEvent, SendMessageRequest>();
        }
    }
}
