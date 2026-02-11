using AutoMapper;
using MediatR;
using MessageService.Domain;

namespace MessageService.Application.UseCases.GetMessage
{
    internal class GetMessageHandler(IIdentityService identityService, IMessageRepository messageRepository,IMapper mapper) : IRequestHandler<GetMessageRequest, IEnumerable<GetMessageResponse>>
    {
        public async Task<IEnumerable<GetMessageResponse>> Handle(GetMessageRequest request, CancellationToken cancellationToken)
        {
            var receiverId = identityService.UserId;
            var messages = await messageRepository.GetByReceiverIdAsync(receiverId,request.Cursor, request.RecordsPerPage, cancellationToken);
            return mapper.Map<IEnumerable<Message>, IEnumerable<GetMessageResponse>>(messages);
        }
    }
}
