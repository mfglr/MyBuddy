using Microsoft.EntityFrameworkCore;
using StudyProgramInviteService.Domain;

namespace StudyProgramInviteService.Infrastructure.PostgreSql
{
    internal class SPIRepository(SqlContext context) : ISPIRepository
    {
        public Task<bool> ExistAsync(Guid studyProgramId, Guid userId, CancellationToken cancellationToken) =>
            context.StudyProgramInvites.AnyAsync(x => x.StudyProgramId == studyProgramId && x.UserId == userId, cancellationToken);

        public Task<SPI?> GetAsync(Guid studyProgramId, Guid userId, CancellationToken cancellationToken) =>
            context.StudyProgramInvites.FirstOrDefaultAsync(x => x.StudyProgramId == studyProgramId && x.UserId == userId, cancellationToken);

        public async Task CreateAsync(SPI spi, CancellationToken cancellationToken) =>
            await context.StudyProgramInvites.AddAsync(spi, cancellationToken);
    }
}
