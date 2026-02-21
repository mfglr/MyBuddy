using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudyProgramInviteService.Application.UseCases.CreateSPI;

namespace StudyProgramInviteService.Api.Controllers
{
    [Authorize("user")]
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class StudyProgramInvitesController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public Task Create(CreateSPIRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
    }
}
