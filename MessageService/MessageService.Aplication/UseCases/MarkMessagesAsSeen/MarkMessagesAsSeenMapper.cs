using AutoMapper;
using MessageService.Domain.MessageAggregate;
using Shared.Events.MessageService;

namespace MessageService.Aplication.UseCases.MarkMessagesAsSeen
{
    internal class MarkMessagesAsSeenMapper : Profile
    {
        public MarkMessagesAsSeenMapper()
        {
            CreateMap<Message, MessagesMarkedAsSeenEvent_Message>();
        }
    }
}
