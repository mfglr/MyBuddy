using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudyProgramApplicationService.Application.UseCases.CreateStudyProgramApplication;

namespace StudyProgramApplicationService.Api.Controllers
{
    [Authorize("user")]
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class StudyProgramApplicationsController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public Task Create(CreateStudyProgramApplicationRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
    }
}
