using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudyProgramService.Application.UseCases.CreateSP;
using StudyProgramService.Application.UseCases.DeleteSP;
using StudyProgramService.Application.UseCases.MarkSPAsActive;
using StudyProgramService.Application.UseCases.MarkSPAsCompleted;
using StudyProgramService.Application.UseCases.MarkSPAsDraft;
using StudyProgramService.Application.UseCases.MarkSPAsInProgress;
using StudyProgramService.Application.UseCases.UpdateSPDescription;
using StudyProgramService.Application.UseCases.UpdateSPPrice;
using StudyProgramService.Application.UseCases.UpdateSPSchedule;
using StudyProgramService.Application.UseCases.UpdateSPTitle;

namespace StudyProgramService.Api.Controllers
{
    [Authorize("user")]
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class StudyProgramsController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public Task<CreateSPResponse> Create(CreateSPRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
        
        [HttpPut]
        public Task MarkAsDraft(MarkSPAsDraftRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
        
        [HttpPut]
        public Task MarkAsActive(MarkSPAsActiveRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
        
        [HttpPut]
        public Task MarkAsInProgress(MarkSPAsInProgressRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
        
        [HttpPut]
        public Task MarkAsCompleted(MSPAsCompletedRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
        
        [HttpDelete("{id:guid}")]
        public Task Delete(Guid id, CancellationToken cancellationToken) =>
            sender.Send(new DeleteSPRequest(id), cancellationToken);

        [HttpPut]
        public Task UpdateSchedule(UpdateSPScheduleRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);

        [HttpPut]
        public Task UpdatePrice(UpdateSPPriceRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);

        [HttpPut]
        public Task UpdateTitle(UpdateSPTitleRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);

        [HttpPut]
        public Task UpdateDescription(UpdateSPDescriptionRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
    }
}
