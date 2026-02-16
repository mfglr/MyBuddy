using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudyProgramService.Application.UseCases.RequestEnrollment;

namespace StudyProgramService.Api.Controllers
{
    [Authorize("user")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EnrollmentRequestsController(ISender sender) : ControllerBase
    {
        public Task Create(RequestEnrollmentRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
    }
}
