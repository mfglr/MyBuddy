namespace Shared.Events.StudyProgramService
{
    public record SPMarkedAsActiveEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        int Version,
        bool IsDeleted,
        Guid UserId,
        string Title,
        string Description,
        int DailyStudyTarget,
        int DaysPerWeek,
        int DurationInWeeks,
        int Status
    );
}
