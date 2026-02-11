using AutoMapper;
using MessageService.Domain;
using Shared.Events.MessageService;

namespace MessageService.Application.UseCases.CreateMessage
{
    internal class CreateMessageMapper : Profile
    {
        public CreateMessageMapper()
        {
            CreateMap<Message, MessageCreatedEvent_Message>();
        }
    }
}
