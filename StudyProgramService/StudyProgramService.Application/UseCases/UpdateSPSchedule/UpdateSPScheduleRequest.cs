using MediatR;

namespace StudyProgramService.Application.UseCases.UpdateSPSchedule
{
    public record UpdateSPScheduleRequest(
        Guid Id,
        int DailyStudyTarget,
        int DaysPerWeek,
        int DurationInWeeks
    ) : IRequest;
}
