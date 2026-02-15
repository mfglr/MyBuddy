using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudyProgramService.Application.UseCases.CreateStudyProgram;
using StudyProgramService.Application.UseCases.DeleteStudyProgram;
using StudyProgramService.Application.UseCases.MarkStudyProgramAsActive;
using StudyProgramService.Application.UseCases.MarkStudyProgramAsCompleted;
using StudyProgramService.Application.UseCases.MarkStudyProgramAsDraft;
using StudyProgramService.Application.UseCases.MarkStudyProgramAsInProgress;
using StudyProgramService.Application.UseCases.UpdateCapacity;
using StudyProgramService.Application.UseCases.UpdateDescription;
using StudyProgramService.Application.UseCases.UpdatePrice;
using StudyProgramService.Application.UseCases.UpdateSchedule;
using StudyProgramService.Application.UseCases.UpdateTitle;

namespace StudyProgramService.Api.Controllers
{
    [Authorize("user")]
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class StudyProgramsController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public Task<CreateStudyProgramResponse> Create(CreateStudyProgramRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
        
        [HttpPut]
        public Task MarkAsDraft(MarkStudyProgramAsDraftRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
        
        [HttpPut]
        public Task MarkAsActive(MarkStudyProgramAsActiveRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
        
        [HttpPut]
        public Task MarkAsInProgress(MarkStudyProgramAsInProgressRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
        
        [HttpPut]
        public Task MarkAsCompleted(MarkStudyProgramAsCompletedRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
        
        [HttpDelete("{id:guid}")]
        public Task Delete(Guid id, CancellationToken cancellationToken) =>
            sender.Send(new DeleteStudyProgramRequest(id), cancellationToken);

        [HttpPut]
        public Task UpdateSchedule(UpdateScheduleRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);

        [HttpPut]
        public Task UpdatePrice(UpdatePriceRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);

        [HttpPut]
        public Task UpdateTitle(UpdateTitleRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);

        [HttpPut]
        public Task UpdateDescription(UpdateDescriptionRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);

        [HttpPut]
        public Task UpdateCapacity(UpdateCapacityRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
    }
}
