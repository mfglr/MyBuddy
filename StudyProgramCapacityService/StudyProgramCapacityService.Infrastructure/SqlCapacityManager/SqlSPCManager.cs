using Microsoft.EntityFrameworkCore;
using StudyProgramCapacityService.Application;
using StudyProgramCapacityService.Domain;

namespace StudyProgramCapacityService.Infrastructure.SqlCapacityManager
{
    internal class SqlSPCManager(SqlContext context) : ISPCManager
    {

        public Task<SPC?> Get(Guid id) =>
            context.StudyProgramCapacities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task Create(Guid id, Guid studyProgramOwnerId, int capacity)
        {
            var studyProgramCapacity = new SPC(id, studyProgramOwnerId, capacity);
            await context.StudyProgramCapacities.AddAsync(studyProgramCapacity);
            await context.SaveChangesAsync();
        }

        public Task Delete(Guid id) =>
            context.StudyProgramCapacities.Where(x => x.Id == id).ExecuteDeleteAsync();

        public async Task Reserve(Guid id)
        {
            var count = await context.StudyProgramCapacities
                .Where(x => x.Id == id && x.EnrollmentCount < x.Capacity)
                .ExecuteUpdateAsync(
                    setters => setters
                        .SetProperty(x => x.EnrollmentCount, x => x.EnrollmentCount + 1)
                        .SetProperty(x => x.Version, x => x.Version + 1)
                );
            if (count < 1)
                throw new InsufficientCapacityException();
        }
        
        public async Task Release(Guid id)
        {
            var count = await context.StudyProgramCapacities
                .Where(x => x.Id == id && x.EnrollmentCount > 0)
                .ExecuteUpdateAsync(
                    setters => setters
                        .SetProperty(x => x.EnrollmentCount, x => x.EnrollmentCount - 1)
                        .SetProperty(x => x.Version, x => x.Version + 1)
                );

            if (count < 1)
                throw new NoEnrollmentToCancelException();
        }

        public async Task Update(Guid id, int capacity)
        {
            var count = await context.StudyProgramCapacities
                .Where(x => x.Id == id && x.EnrollmentCount <= capacity)
                .ExecuteUpdateAsync(
                    setters => setters
                        .SetProperty(x => x.Capacity, x => capacity)
                        .SetProperty(x => x.Version, x => x.Version + 1)
                );
            if (count < 1)
                throw new CapacityLessThanEnrollmentException();
        }
    }
}
