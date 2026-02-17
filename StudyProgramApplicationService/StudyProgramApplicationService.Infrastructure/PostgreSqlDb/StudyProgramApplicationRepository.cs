using Microsoft.EntityFrameworkCore;
using StudyProgramApplicationService.Domain;

namespace StudyProgramApplicationService.Infrastructure.PostgreSqlDb
{
    internal class StudyProgramApplicationRepository(PostgreSqlContext context) : IStudyProgramApplicationRepository
    {
        public async Task CreateAsync(StudyProgramApplication application, CancellationToken cancellationToken) =>
            await context.StudyProgramApplications.AddAsync(application, cancellationToken);

        public Task<StudyProgramApplication?> GetAsync(Guid studyProgramId, Guid userId, CancellationToken cancellationToken) =>
            context.StudyProgramApplications.FirstOrDefaultAsync(x => x.StudyProgramId == studyProgramId && x.UserId == userId, cancellationToken);
    }
}
