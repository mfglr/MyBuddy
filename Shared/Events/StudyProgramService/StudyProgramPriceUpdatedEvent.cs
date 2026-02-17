namespace Shared.Events.StudyProgramService
{
    public record StudyProgramPriceUpdatedEvent(
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
        string Status,
        int Capacity
    );
}
