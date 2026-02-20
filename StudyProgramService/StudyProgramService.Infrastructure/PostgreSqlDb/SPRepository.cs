using MassTransit;
using Microsoft.EntityFrameworkCore;
using StudyProgramService.Domain.Abstracts;
using StudyProgramService.Domain.Entities;

namespace StudyProgramService.Infrastructure.PostgreSqlDb
{
    internal class SPRepository(PostgreSqlContext context) : ISPRepository
    {
        public Task<SP?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
            context.StudyPrograms.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task CreateAsync(SP studyProgram, CancellationToken cancellationToken) =>
            await context.StudyPrograms.AddAsync(studyProgram,cancellationToken);

        public void Delete(SP studyProgram) =>
            context.StudyPrograms.Remove(studyProgram);

        public Task<List<SP>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken) =>
            context.StudyPrograms.Where(x => x.UserId == userId).ToListAsync(cancellationToken);
    }
}
