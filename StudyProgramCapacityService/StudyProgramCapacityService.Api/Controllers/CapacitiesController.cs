using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudyProgramCapacityService.Application.UseCases.GetSPCById;
using StudyProgramCapacityService.Application.UseCases.UpdateCapacity;

namespace StudyProgramCapacityService.Api.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class CapacitiesController(ISender sender) : ControllerBase
    {
        [HttpGet("{id:guid}")]
        public Task<GetSPCByIdResponse> GetById(Guid id, CancellationToken cancellationToken) =>
            sender.Send(new GetSPCByIdRequest(id), cancellationToken);

        [Authorize("user")]
        [HttpPut]
        public Task Update(UpdateCapacityRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
    }
}
