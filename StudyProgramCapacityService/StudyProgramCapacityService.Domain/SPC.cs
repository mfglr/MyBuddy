namespace StudyProgramCapacityService.Domain
{
    [GenerateSerializer]
    [Alias("StudyProgramCapacityService.Domain.SPC")]
    public class SPC(Guid id, Guid studyProgramOwnerId, int capacity)
    {
        [Id(0)]
        public Guid Id { get; private set; } = id;
        [Id(1)]
        public Guid StudyProgramOwnerId { get; private set; } = studyProgramOwnerId;
        [Id(2)]
        public int Capacity { get; private set; } = capacity;
        [Id(3)]
        public int EnrollmentCount { get; private set; } = 0;
        [Id(4)]
        public int Version { get; private set; } = 1;

        public bool IsDefault => Capacity == 0 && EnrollmentCount == 0 && Version == 0;

        public void Update(int capacity)
        {
            if (capacity <= EnrollmentCount)
                throw new CapacityLessThanEnrollmentException();

            Capacity = capacity;
            Version++;
        }

        public void Reserve()
        {
            if(EnrollmentCount + 1 > Capacity)
                throw new InsufficientCapacityException();

            EnrollmentCount++;
            Version++;
        }

        public void Release()
        {
            if (EnrollmentCount - 1 < 0)
                throw new NoEnrollmentToCancelException();

            EnrollmentCount--;
            Version++;
        }
    }
}
