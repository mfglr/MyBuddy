using StudyProgramService.Domain.StudyProgramAggregate.Exceptions;

namespace StudyProgramService.Domain.StudyProgramAggregate.ValueObjects
{
    public class StudyProgramCurrency
    {

        private class Values
        {
            public readonly static string TRY = "TRY";
            public readonly static string USD = "USD";
            public readonly static string EUR = "EUR";

            public static bool IsValid(string value)
            {
                string v = value.Trim().ToUpper();
                return
                    v == TRY ||
                    v == USD ||
                    v == EUR;
            }
        }

        public string Value { get; private set; }

        public StudyProgramCurrency(string value)
        {
            if (!Values.IsValid(value))
                throw new InvalidCurrencyValueException();
            Value = value;
        }

        public static StudyProgramCurrency TRY() => new (Values.TRY);

        public static bool operator ==(StudyProgramCurrency x, StudyProgramCurrency y) => x.Value == y.Value;
        public static bool operator !=(StudyProgramCurrency x, StudyProgramCurrency y) => x.Value != y.Value;
    }
}
