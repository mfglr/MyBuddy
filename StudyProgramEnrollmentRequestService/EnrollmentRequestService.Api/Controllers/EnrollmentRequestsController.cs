using EnrollmentRequestService.Application.UseCases.CreateEnrollmentRequest;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnrollmentRequestService.Api.Controllers
{
    [Authorize("user")]
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class EnrollmentRequestsController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public Task RequestEnrollment(CreateEnrollmentRequest_Request request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
    }
}
