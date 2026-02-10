using AutoMapper;
using MessageService.Domain.MessageDeliveryAggregate;
using Shared.Events.MessageService;

namespace MessageService.Aplication.UseCases.MarkMessagesAsDelivered
{
    internal class MarkMessagesAsDeliveredMapper : Profile
    {
        public MarkMessagesAsDeliveredMapper()
        {
            CreateMap<MessageDelivery, MessagesMarkedAsDeliveredEvent_MessageDelivery>();
        }
    }
}
