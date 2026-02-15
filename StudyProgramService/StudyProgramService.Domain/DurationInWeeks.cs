namespace StudyProgramService.Domain
{
    public class DurationInWeeks
    {
        private static class DurationInWeeksValue
        {
            public static readonly int ShortTerm = 4;
            public static readonly int ExamPeriod = 8;
            public static readonly int Intensive = 12;
        }


        public static readonly int Max = 52;
        public static readonly int Min = 1;

        public int Value { get; private set; }


        public DurationInWeeks(int value)
        {
            if (value < Min || value > Max)
                throw new InvalidDurationInWeeksValue();
            Value = value;
        }

        public static DurationInWeeks ShortTerm() => new(DurationInWeeksValue.ShortTerm);
        public static DurationInWeeks ExamPeriod() => new(DurationInWeeksValue.ExamPeriod);
        public static DurationInWeeks Intensive() => new(DurationInWeeksValue.Intensive);
    }
}
