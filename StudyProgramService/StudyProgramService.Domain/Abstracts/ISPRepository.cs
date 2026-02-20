using StudyProgramService.Domain.Entities;

namespace StudyProgramService.Domain.Abstracts
{
    public interface ISPRepository
    {
        Task<SP?> GetByIdAsync(Guid Id, CancellationToken cancellationToken);
        Task<List<SP>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
        Task CreateAsync(SP studyProgram, CancellationToken cancellationToken);
        void Delete(SP studyProgram);
    }
}
