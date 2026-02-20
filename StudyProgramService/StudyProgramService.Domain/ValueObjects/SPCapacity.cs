using StudyProgramService.Domain.Exceptions;

namespace StudyProgramService.Domain.ValueObjects
{
    public class SPCapacity
    {
        public int Value { get; private set; }

        public SPCapacity(int value)
        {
            if (value < 1)
                throw new InvalidSPCapacityValueException();
            Value = value;
        }

        public static SPCapacity operator +(int x, SPCapacity y) => new(x + y.Value);
        public static SPCapacity operator +(SPCapacity x, int y) => new(x.Value + y);
    }
}
