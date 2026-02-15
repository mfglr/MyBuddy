using MediatR;

namespace StudyProgramService.Application.UseCases.UpdateSchedule
{
    public record UpdateScheduleRequest(
        Guid Id,
        int DailyStudyTarget,
        int DaysPerWeek,
        int DurationInWeeks
    ) : IRequest;
}
