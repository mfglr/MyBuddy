namespace StudyProgramService.Domain
{
    public interface IStudyProgramRepository
    {
        Task<StudyProgram?> GetByIdAsync(Guid Id, CancellationToken cancellationToken);
        Task<List<StudyProgram>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
        Task CreateAsync(StudyProgram studyProgram, CancellationToken cancellationToken);
        Task UpdateAsync(StudyProgram studyProgram, CancellationToken cancellationToken);
        Task UpdateAsync(IEnumerable<StudyProgram> studyPrograms, CancellationToken cancellationToken);
        Task DeleteAsync(StudyProgram studyProgram, CancellationToken cancellationToken);
    }
}
