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

        public static StudyProgramCapacity operator +(int x, StudyProgramCapacity y) => new(x + y.Value);
        public static StudyProgramCapacity operator +(StudyProgramCapacity x, int y) => new(x.Value + y);
    }
}
