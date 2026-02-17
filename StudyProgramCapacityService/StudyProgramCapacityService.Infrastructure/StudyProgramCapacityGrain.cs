using Orleans.Providers;
using StudyProgramCapacityService.Domain;

namespace StudyProgramCapacityService.Infrastructure
{
    [StorageProvider(ProviderName = "StudyProgramCapacity")]
    internal class StudyProgramCapacityGrain : Grain<StudyProgramCapacity>, IStudyProgramCapacityGrain
    {
        public Task Create(int capacity, int capacityVersion)
        {
            if (State == default)
                State = new StudyProgramCapacity(capacity, capacityVersion);
            else
                State.UpdateCapacity(capacity, capacityVersion);
            return WriteStateAsync();
        }

        public async Task<StudyProgramCapacity> CancellEnrollment()
        {
            if (State == default)
                State = new();

            State.CancelEnrollment();
            await WriteStateAsync();
            return State;
        }
        
        public async Task<StudyProgramCapacity> Enroll()
        {
            if (State == default)
                State = new();
            State.Enroll();
            await WriteStateAsync();
            return State;
        }

        public Task UpdateCapacity(int capacity, int capacityVersion)
        {
            if (State == default)
                State = new();

            if (capacityVersion <= State.CapacityVersion)
                return Task.CompletedTask;

            State.UpdateCapacity(capacity, capacityVersion);
            return WriteStateAsync();
        }
    }
}
