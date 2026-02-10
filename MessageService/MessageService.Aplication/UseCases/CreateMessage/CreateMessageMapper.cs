using AutoMapper;
using MessageService.Domain.MessageAggregate;
using Shared.Events.MessageService;

namespace MessageService.Aplication.UseCases.CreateMessage
{
    internal class CreateMessageMapper : Profile
    {
        public CreateMessageMapper(){
            CreateMap<Message, MessageCreatedEvent>()
                .ForCtorParam("Content", x => x.MapFrom(m => m.Content.Value));
        }
    }
}
