using Orleans.Providers;
using StudyProgramCapacityService.Domain;

namespace StudyProgramCapacityService.Infrastructure.OrleanSPCManager
{
    [StorageProvider(ProviderName = "StudyProgramCapacity")]
    internal class SPCGrain : Grain<SPC>, ISPCGrain
    {

        public Task<SPC?> Get() => Task.FromResult(State.IsDefault ? null : State);

        public Task Create(Guid studyProgramOwnerId, int capacity)
        {
            State = new SPC(this.GetPrimaryKey(), studyProgramOwnerId, capacity);
            return WriteStateAsync();
        }

        public async Task<SPC> Release()
        {
            State.Release();
            await WriteStateAsync();
            return State;
        }
        
        public async Task<SPC> Reserve()
        {
            State.Reserve();
            await WriteStateAsync();
            return State;
        }

        public async Task<SPC> Update(int capacity)
        {
            State.Update(capacity);
            await WriteStateAsync();
            return State;
        }

        public async Task Delete()
        {
            await ClearStateAsync();
            DeactivateOnIdle();
        }
    }
}
