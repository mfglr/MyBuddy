namespace StudyProgramInviteService.Domain
{
    public interface ISPIRepository
    {
        Task<bool> ExistAsync(Guid studyProgramId, Guid userId, CancellationToken cancellationToken);
        Task<SPI?> GetAsync(Guid studyProgramId, Guid userId, CancellationToken cancellationToken);
        Task CreateAsync(SPI spi, CancellationToken cancellationToken);
    }
}
