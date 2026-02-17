using MongoDB.Driver.Linq;
using StudyProgramService.Domain.StudyProgramAggregate.Abstracts;
using StudyProgramService.Domain.StudyProgramAggregate.Entities;

namespace StudyProgramService.Infrastructure.PostgreSqlDb
{
    internal class StudyProgramRepository(PostgreSqlContext context) : IStudyProgramRepository
    {
        public Task<StudyProgram?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
            context.StudyPrograms.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task CreateAsync(StudyProgram studyProgram, CancellationToken cancellationToken) =>
            await context.StudyPrograms.AddAsync(studyProgram,cancellationToken);

        public void Delete(StudyProgram studyProgram) =>
            context.StudyPrograms.Remove(studyProgram);

        public Task<List<StudyProgram>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken) =>
            context.StudyPrograms.Where(x => x.UserId == userId).ToListAsync(cancellationToken);
    }
}
