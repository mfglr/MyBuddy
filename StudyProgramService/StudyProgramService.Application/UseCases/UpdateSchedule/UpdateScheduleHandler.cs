using MassTransit;
using MediatR;
using StudyProgramService.Domain;
using StudyProgramService.Domain.StudyProgramAggregate.Abstracts;
using StudyProgramService.Domain.StudyProgramAggregate.ValueObjects;

namespace StudyProgramService.Application.UseCases.UpdateSchedule
{
    internal class UpdateScheduleHandler(IUnitOfWork unitOfWork, UpdateScheduleMapper mapper, IIdentityService identityService, IStudyProgramRepository studyProgramRepository, IPublishEndpoint publishEndpoint) : IRequestHandler<UpdateScheduleRequest>
    {
        public async Task Handle(UpdateScheduleRequest request, CancellationToken cancellationToken)
        {
            var dailyStudyTarget = new StudyProgramDailyStudyTarget(request.DailyStudyTarget);
            var daysPerWeek = new StudyProgramDaysPerWeek(request.DaysPerWeek);
            var durationInWeeks = new StudyProgramDurationInWeeks(request.DurationInWeeks);
            var studySchedule = new StudyProgramSchedule(dailyStudyTarget, daysPerWeek, durationInWeeks);

            var studyProgram = await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken);
            if (studyProgram == null || studyProgram.IsDeleted)
                throw new StudyProgramNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new UnauhtrizedOperationException();

            studyProgram.UpdateSchedule(studySchedule);

            await unitOfWork.CommitAsync(cancellationToken);

            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
