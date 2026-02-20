using StudyProgramCapacityService.Domain;

namespace StudyProgramCapacityService.Application.UseCases.GetSPCById
{
    internal class GetSPCByIdMapper
    {
        public GetSPCByIdResponse Map(SPC capacity, Guid StudyProgramId) =>
            new(
                StudyProgramId,
                capacity.Capacity,
                capacity.EnrollmentCount
            );
    }
}
