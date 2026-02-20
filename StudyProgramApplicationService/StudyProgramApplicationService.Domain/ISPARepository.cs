namespace StudyProgramApplicationService.Domain
{
    public interface ISPARepository
    {
        Task<SPA?> GetAsync(Guid studyProgramId, Guid userId, CancellationToken cancellationToken);
        Task CreateAsync(SPA application, CancellationToken cancellationToken);
    }
}
