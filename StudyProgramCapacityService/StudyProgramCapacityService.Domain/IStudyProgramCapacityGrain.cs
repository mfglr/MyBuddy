namespace StudyProgramCapacityService.Domain
{
    [Alias("StudyProgramCapacityService.Domain.IStudyProgramCapacityGrain")]
    public interface IStudyProgramCapacityGrain : IGrainWithGuidKey
    {
        [Alias("Create")] Task Create(int capacity, int capacityVersion);
        [Alias("Enroll")] Task<StudyProgramCapacity> Enroll();
        [Alias("CancellEnrollment")] Task<StudyProgramCapacity> CancellEnrollment();
        [Alias("UpdateCapacity")] Task UpdateCapacity(int capacity, int capacityVersion);
    }
}
