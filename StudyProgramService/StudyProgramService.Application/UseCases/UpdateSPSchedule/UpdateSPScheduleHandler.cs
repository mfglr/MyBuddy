using MassTransit;
using MediatR;
using Shared.Exceptions;
using StudyProgramService.Domain.Abstracts;
using StudyProgramService.Domain.ValueObjects;

namespace StudyProgramService.Application.UseCases.UpdateSPSchedule
{
    internal class UpdateSPScheduleHandler(IUnitOfWork unitOfWork, UpdateSPScheduleMapper mapper, IIdentityService identityService, ISPRepository studyProgramRepository, IPublishEndpoint publishEndpoint) : IRequestHandler<UpdateSPScheduleRequest>
    {
        public async Task Handle(UpdateSPScheduleRequest request, CancellationToken cancellationToken)
        {
            var dailyStudyTarget = new SPDailyStudyTarget(request.DailyStudyTarget);
            var daysPerWeek = new SPDaysPerWeek(request.DaysPerWeek);
            var durationInWeeks = new SPDurationInWeeks(request.DurationInWeeks);

            var studyProgram = await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken);
            if (studyProgram == null || studyProgram.IsDeleted)
                throw new SPNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new AuthorizationException();

            studyProgram.UpdateSchedule(dailyStudyTarget, daysPerWeek, durationInWeeks);
            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
