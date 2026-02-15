using MassTransit;
using MediatR;
using StudyProgramService.Domain;

namespace StudyProgramService.Application.UseCases.UpdateSchedule
{
    internal class UpdateScheduleHandler(UpdateScheduleMapper mapper, IIdentityService identityService, IStudyProgramRepository studyProgramRepository, IPublishEndpoint publishEndpoint) : IRequestHandler<UpdateScheduleRequest>
    {
        public async Task Handle(UpdateScheduleRequest request, CancellationToken cancellationToken)
        {
            var dailyStudyTarget = new DailyStudyTarget(request.DailyStudyTarget);
            var daysPerWeek = new DaysPerWeek(request.DaysPerWeek);
            var durationInWeeks = new DurationInWeeks(request.DurationInWeeks);
            var studySchedule = new Schedule(dailyStudyTarget, daysPerWeek, durationInWeeks);

            var studyProgram =
                await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new StudyProgramNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new UnauhtrizedOperationException();

            studyProgram.UpdateSchedule(studySchedule);
            await studyProgramRepository.UpdateAsync(studyProgram, cancellationToken);

            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
