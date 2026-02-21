namespace Shared.Events.StudyProgramService.StudyProgramInvite
{
    public record SPICreatedEvent(
        Guid StudyProgramId,
        Guid UserId,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        bool IsDeleted,
        int Version,
        Guid StudyProgramOwnerId
    );
}
