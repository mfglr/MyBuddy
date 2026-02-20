using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudyProgramApplicationService.Application.UseCases.CreateSPA;
using StudyProgramApplicationService.Application.UseCases.MarkSPAAsRejected;
using StudyProgramApplicationService.Application.UseCases.RequestSPAApproval;

namespace StudyProgramApplicationService.Api.Controllers
{
    [Authorize("user")]
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class StudyProgramApplicationsController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public Task Create(CreateSPARequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);

        [HttpPut]
        public Task RequestApproval(RequestSPAApprovalRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);

        [HttpPut]
        public Task Reject(MarkSPAAsRejectedRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
    }
}
