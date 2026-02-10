using AutoMapper;
using MediatR;
using MessageService.Domain.MessageAggregate;

namespace MessageService.Aplication.UseCases.GetUnreceivedMessages
{
    internal class GetUnreceivedMessagesHandler(IMessageRepository messageRepository, IMapper mapper) : IRequestHandler<GetUnreceivedMessagesRequest, GetUnreceivedMessagesResponse>
    {
        public async Task<GetUnreceivedMessagesResponse> Handle(GetUnreceivedMessagesRequest request, CancellationToken cancellationToken)
        {
            var messages = await messageRepository.GetBySenderIdAsync(request.UserId, cancellationToken);
            return new(mapper.Map<IEnumerable<Message>, IEnumerable<GetUnreceivedMessagesResponse_Message>>(messages));
        }
    }
}
