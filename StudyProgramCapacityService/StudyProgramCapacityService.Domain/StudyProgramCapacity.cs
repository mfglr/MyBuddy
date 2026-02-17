namespace StudyProgramCapacityService.Domain
{
    public class StudyProgramCapacity
    {
        public int CapacityVersion { get; private set; }
        public int Capacity { get; private set; }
        public int EnrollmentCount { get; private set; }
        public int Version { get; private set; }

        public StudyProgramCapacity()
        {
            Version = 1;
        }

        public StudyProgramCapacity(int capacity, int capacityVersion)
        {
            Capacity = capacity;
            CapacityVersion = capacityVersion;
            EnrollmentCount = 0;
            Version = 1;
        }

        public void UpdateCapacity(int capacity, int capacityVersion)
        {
            if (capacityVersion <= CapacityVersion)
                return;
            Capacity = capacity;
        }

        public void Enroll()
        {
            if(EnrollmentCount + 1 > Capacity)
                throw new InsufficientCapacityException();

            EnrollmentCount++;
            Version++;
        }

        public void CancelEnrollment()
        {
            if (EnrollmentCount - 1 < 0)
                throw new InvalidCapacityValueException();

            EnrollmentCount--;
            Version++;
        }
    }
}
