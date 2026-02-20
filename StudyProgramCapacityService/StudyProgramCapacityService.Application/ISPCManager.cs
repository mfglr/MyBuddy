using StudyProgramCapacityService.Domain;

namespace StudyProgramCapacityService.Application
{
    public interface ISPCManager
    {
        Task<SPC?> Get(Guid id);
        Task Create(Guid id, Guid studyProgramOwnerId, int capacity);
        Task Delete(Guid id);
        Task Reserve(Guid id);
        Task Release(Guid id);
        Task Update(Guid id, int capacity);
    }
}
