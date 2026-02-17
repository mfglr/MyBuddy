namespace StudyProgramService.Domain
{
    public class StudyProgramDurationInWeeks
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


        public StudyProgramDurationInWeeks(int value)
        {
            if (value < Min || value > Max)
                throw new InvalidDurationInWeeksValueException();
            Value = value;
        }

        public static StudyProgramDurationInWeeks ShortTerm() => new(DurationInWeeksValue.ShortTerm);
        public static StudyProgramDurationInWeeks ExamPeriod() => new(DurationInWeeksValue.ExamPeriod);
        public static StudyProgramDurationInWeeks Intensive() => new(DurationInWeeksValue.Intensive);
    }
}
