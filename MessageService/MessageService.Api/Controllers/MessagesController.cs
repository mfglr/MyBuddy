using MediatR;
using MessageService.Application.UseCases.CreateMessage;
using MessageService.Application.UseCases.DeleteMessage;
using MessageService.Application.UseCases.GetMessage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MessageService.Api.Controllers
{
    [Authorize("user")]
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class MessagesController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public Task Create(CreateMessageRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);

        [HttpPost]
        public Task Delete(DeleteMessageRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);

        [HttpGet]
        public Task<IEnumerable<GetMessageResponse>> Get([FromQuery]GetMessageRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
    }
}
