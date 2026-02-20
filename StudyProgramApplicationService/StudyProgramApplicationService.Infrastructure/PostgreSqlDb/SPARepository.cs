using Microsoft.EntityFrameworkCore;
using StudyProgramApplicationService.Domain;

namespace StudyProgramApplicationService.Infrastructure.PostgreSqlDb
{
    internal class SPARepository(PostgreSqlContext context) : ISPARepository
    {
        public async Task CreateAsync(SPA application, CancellationToken cancellationToken) =>
            await context.StudyProgramApplications.AddAsync(application, cancellationToken);

        public Task<SPA?> GetAsync(Guid studyProgramId, Guid userId, CancellationToken cancellationToken) =>
            context.StudyProgramApplications.FirstOrDefaultAsync(x => x.StudyProgramId == studyProgramId && x.UserId == userId, cancellationToken);
    }
}
