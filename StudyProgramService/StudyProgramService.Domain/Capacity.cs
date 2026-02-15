namespace StudyProgramService.Domain
{
    public class Capacity
    {
        public int Value { get; private set; }

        public Capacity(int value)
        {
            if (value < 1)
                throw new InvalidCapacityValueException();
            Value = value;
        }
    }
}
