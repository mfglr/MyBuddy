using StudyProgramService.Domain.StudyProgramAggregate.Entities;

namespace StudyProgramService.Domain.StudyProgramAggregate.Abstracts
{
    public interface IStudyProgramRepository
    {
        Task<StudyProgram?> GetByIdAsync(Guid Id, CancellationToken cancellationToken);
        Task<List<StudyProgram>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
        Task CreateAsync(StudyProgram studyProgram, CancellationToken cancellationToken);
        void Delete(StudyProgram studyProgram);
    }
}
