using StudyProgramCapacityService.Application;
using StudyProgramCapacityService.Domain;

namespace StudyProgramCapacityService.Infrastructure.OrleanSPCManager
{
    internal class OrleansSPCManager(IGrainFactory grainFactory) : ISPCManager
    {

        public Task<SPC?> Get(Guid id)
        {
            var grain = grainFactory.GetGrain<ISPCGrain>(id);
            return grain.Get();
        }

        public Task Create(Guid id, Guid studyProgramOwnerId, int capacity)
        {
            var grain = grainFactory.GetGrain<ISPCGrain>(id);
            return grain.Create(studyProgramOwnerId, capacity);
        }
        public Task Delete(Guid id)
        {
            var grain = grainFactory.GetGrain<ISPCGrain>(id);
            return grain.Delete();
        }
        public Task Reserve(Guid id)
        {
            var grain = grainFactory.GetGrain<ISPCGrain>(id);
            return grain.Reserve();
        }
        public Task Release(Guid id)
        {
            var grain = grainFactory.GetGrain<ISPCGrain>(id);
            return grain.Release();
        }
        public Task Update(Guid id, int capacity)
        {
            var grain = grainFactory.GetGrain<ISPCGrain>(id);
            return grain.Update(capacity);
        }
    }
}
