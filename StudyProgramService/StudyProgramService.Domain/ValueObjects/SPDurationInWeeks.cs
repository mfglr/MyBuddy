using StudyProgramService.Domain.Exceptions;

namespace StudyProgramService.Domain.ValueObjects
{
    public class SPDurationInWeeks
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


        public SPDurationInWeeks(int value)
        {
            if (value < Min || value > Max)
                throw new InvalidSPDurationInWeeksValueException();
            Value = value;
        }

        public static SPDurationInWeeks ShortTerm() => new(DurationInWeeksValue.ShortTerm);
        public static SPDurationInWeeks ExamPeriod() => new(DurationInWeeksValue.ExamPeriod);
        public static SPDurationInWeeks Intensive() => new(DurationInWeeksValue.Intensive);
    }
}
