namespace StudyProgramCapacityService.Domain
{
    [Alias("StudyProgramCapacityService.Domain.ISPCGrain")]
    public interface ISPCGrain : IGrainWithGuidKey
    {
        [Alias("GetById")] Task<SPC?> Get();
        [Alias("Create")] Task Create(Guid studyProgramOwnerId, int capacity);
        [Alias("Delete")] Task Delete();
        [Alias("Reserve")] Task<SPC> Reserve();
        [Alias("Release")] Task<SPC> Release();
        [Alias("Update")] Task<SPC> Update(int capacity);
    }
}
