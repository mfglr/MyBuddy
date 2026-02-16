using StudyProgramService.Domain.StudyProgramAggregate.Exceptions;

namespace StudyProgramService.Domain.StudyProgramAggregate.ValueObjects
{
    public class StudyProgramCapacity
    {
        public int Value { get; private set; }

        public StudyProgramCapacity(int value)
        {
            if (value < 1)
                throw new InvalidCapacityValueException();
            Value = value;
        }

        public static bool operator >(StudyProgramCapacity x, StudyProgramCapacity y) => x.Value > y.Value;
        public static bool operator <(StudyProgramCapacity x, StudyProgramCapacity y) => x.Value < y.Value;
        public static bool operator >=(StudyProgramCapacity x, StudyProgramCapacity y) => x.Value >= y.Value;
        public static bool operator <=(StudyProgramCapacity x, StudyProgramCapacity y) => x.Value <= y.Value;

        public static bool operator >(int x, StudyProgramCapacity y) => x > y.Value;
        public static bool operator <(int x, StudyProgramCapacity y) => x < y.Value;
        public static bool operator >(StudyProgramCapacity x, int y) => x.Value > y;
        public static bool operator <(StudyProgramCapacity x, int y) => x.Value < y;
        public static bool operator >=(int x, StudyProgramCapacity y) => x >= y.Value;
        public static bool operator <=(int x, StudyProgramCapacity y) => x <= y.Value;
        public static bool operator >=(StudyProgramCapacity x, int y) => x.Value >= y;
        public static bool operator <=(StudyProgramCapacity x, int y) => x.Value <= y;
    }
}
