namespace StudyProgramApplicationService.Domain
{
    public interface IStudyProgramApplicationRepository
    {
        Task<StudyProgramApplication?> GetAsync(Guid studyProgramId, Guid userId, CancellationToken cancellationToken);
        Task CreateAsync(StudyProgramApplication application, CancellationToken cancellationToken);
    }
}
